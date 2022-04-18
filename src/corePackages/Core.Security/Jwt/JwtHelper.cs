using Core.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Extensions;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        public Task<AccessToken> CreateToken(IdentityUser user, IList<string> operationClaims)
        {
            var result = Task.Run(() =>
           {
               _accessTokenExpiration = DateTime.Now.AddDays(_tokenOptions.AccessTokenExpiration);
               var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
               var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
               var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
               var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
               var token = jwtSecurityTokenHandler.WriteToken(jwt);

               return new AccessToken
               {
                   Token = token,
                   Expiration = _accessTokenExpiration
               };
           });
            return result;
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, IdentityUser user,
            SigningCredentials signingCredentials, IList<string> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims.ToList() ),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(IdentityUser user, List<string> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.Add(new Claim("username", user.UserName));
            claims.AddRoles(operationClaims.ToArray() );

            return claims;
        }
    }
}
