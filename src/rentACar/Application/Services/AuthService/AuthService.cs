using Core.Persistence.Identity;
using Core.Security.Jwt;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public class AuthService: IAuthService
    {
        private ITokenHelper _tokenHelper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService( ITokenHelper tokenHelper,
            UserManager<ApplicationUser> userManager
           )
        {
            _tokenHelper = tokenHelper;
            _userManager = userManager;
        }

        public async Task<bool> UserExists(string email)
        { 
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<AccessToken> CreateAccessToken(IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user as ApplicationUser);
            var accessToken = await _tokenHelper.CreateToken(user, userRoles);
            return accessToken;
        }
    }

}
