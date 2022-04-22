using Core.Domain;
using Core.Domain.Entities;
using Core.Security.Jwt;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(ApplicationUser user, string password);

        Task<Result> DeleteUserAsync(string userId);

        Task<ApplicationUser> FindByNameAsync(string userName);

        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);

        Task<IList<string>> GetRolesAsync(ApplicationUser user);

        Task<AccessToken> CreateAccessToken(ApplicationUser user);
    }
}
