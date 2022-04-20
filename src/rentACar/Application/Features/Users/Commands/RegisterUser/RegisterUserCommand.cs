using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Identity;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Core.Utilities.Messages;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand :IRequest<CreateUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<RegisterUserCommand, CreateUserDto>
        {
            private readonly IMapper _mapper;
            private readonly UserBusinessRules userBusinessRules;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public CreateUserCommandHandler(
                IMapper mapper,
                UserBusinessRules userBusinessRules,
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager)
            {
                _mapper = mapper;
                this.userBusinessRules = userBusinessRules;
                _userManager = userManager;
                _roleManager = roleManager;
            }

            public async Task<CreateUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var userExists = await _userManager.FindByNameAsync(request.Username);

                if (userExists != null)
                    throw new BusinessException(Messages.UsernameAlreadyTaken);

                var userToAdd = _mapper.Map<ApplicationUser>(request);
                userToAdd.SecurityStamp = Guid.NewGuid().ToString();
                
                var result = await _userManager.CreateAsync(userToAdd, request.Password);

                if (!result.Succeeded)
                    throw new BusinessException("Kullanıcı oluşturulurken bir hata oluştu. Sonra tekrar deneyin.");

                
                var userToReturn =  _mapper.Map<CreateUserDto>(_userManager.FindByNameAsync(request.Username) );
                return userToReturn;
            }
        }
    }
}
