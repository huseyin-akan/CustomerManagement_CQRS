using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Messages;
using MediatR;
using System;
using System.Collections.Generic;
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
            private readonly IIdentityService _identityService;

            public LoginUserCommandHandler(
                IMapper mapper,
                UserBusinessRules userBusinessRules,
                IIdentityService identityService)
            {
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _identityService = identityService;
            }
            public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var userToCheck = await _identityService.FindByNameAsync(request.Username);

                if (userToCheck is null)
                {
                    throw new BusinessException(Messages.UserNotFound);
                }

                if ((await _identityService.CheckPasswordAsync(userToCheck, request.Password)) != true)
                {
                    throw new BusinessException(Messages.PasswordError);
                }

                var userRoles = await _identityService.GetRolesAsync(userToCheck);

                var accessToken = await _identityService.CreateAccessToken(userToCheck);

                return new LoginUserDto
                {
                    AccessToken = accessToken
                };
            }
            
        }
    }
}
