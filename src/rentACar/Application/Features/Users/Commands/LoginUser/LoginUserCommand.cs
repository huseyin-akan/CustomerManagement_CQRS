using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Identity;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Core.Utilities.Messages;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand :IRequest<LoginUserDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserDto>
        {
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IAuthService _authService;
            private readonly UserManager<ApplicationUser> _userManager;

            public LoginUserCommandHandler(
                IMapper mapper,
                UserBusinessRules userBusinessRules,
                IAuthService authService,
                UserManager<ApplicationUser> userManager)
            {
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _authService = authService;
                _userManager = userManager;
            }
            public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var userToCheck = await _userManager.FindByNameAsync(request.Username);

                if (userToCheck is null)
                {
                    throw new BusinessException(Messages.UserNotFound);
                }

                if (await _userManager.CheckPasswordAsync(userToCheck, request.Password))
                {
                    throw new BusinessException(Messages.PasswordError);
                }

                var userRoles = await _userManager.GetRolesAsync(userToCheck);

                var accessToken = await _authService.CreateAccessToken(userToCheck);

                return new LoginUserDto
                {
                    AccessToken = accessToken
                };
            }
            
        }
    }
}
