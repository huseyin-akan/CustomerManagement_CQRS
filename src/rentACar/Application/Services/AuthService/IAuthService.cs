using Core.Security.Dtos;
using Core.Security.Jwt;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public interface IAuthService
    {
        Task<bool> UserExists(string email);
        Task<AccessToken> CreateAccessToken(IdentityUser user);
    }
}
