using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Services;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities;
using Core.Utilities.Messages;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<CreateUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNumber { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<RegisterUserCommand, CreateUserDto>
        {
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IIdentityService _identityService;

            public CreateUserCommandHandler(
                IMapper mapper,
                UserBusinessRules userBusinessRules,
                IIdentityService identityService)
            {
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _identityService = identityService;
            }

            public async Task<CreateUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var userExists = await _identityService.FindByNameAsync(request.Username);

                if (userExists != null)
                    throw new BusinessException(Messages.UsernameAlreadyTaken);

                var userToAdd = _mapper.Map<ApplicationUser>(request);
                userToAdd.SecurityStamp = Guid.NewGuid().ToString();

                var result = await _identityService.CreateUserAsync(userToAdd, request.Password);

                if (!result.Result.Success)
                    throw new BusinessException("Kullanıcı oluşturulurken bir hata oluştu. Sonra tekrar deneyin.");

                var userToReturn = _mapper.Map<CreateUserDto>(await _identityService.FindByNameAsync(request.Username));
                return userToReturn;
            }
        }
    }
}
