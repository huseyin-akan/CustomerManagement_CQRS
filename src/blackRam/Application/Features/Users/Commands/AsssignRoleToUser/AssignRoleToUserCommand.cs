using Core.Application.Services;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.IssueClaimToUser
{
    public class AssignRoleToUserCommand : IRequest<Result>
    {
        public string UserId { get; set; }
        public string Role { get; set; }

        public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommand, Result>
        {
            private readonly IIdentityService _identityService;

            public AssignRoleToUserCommandHandler(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            public async Task<Result> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
            {
                var result = await _identityService.AddUserToRole(request.UserId, request.Role);
                return result ? new SuccessResult() : new ErrorResult();
            }
        }
    }
}
