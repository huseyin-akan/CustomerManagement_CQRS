using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Jwt
{
    public interface ITokenHelper
    {
        Task<AccessToken> CreateToken(IdentityUser user, IList<string> operationClaims);
    }
}
