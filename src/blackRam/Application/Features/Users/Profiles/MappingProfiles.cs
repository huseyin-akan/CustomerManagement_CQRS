using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Dtos;
using AutoMapper;
using Core.Domain.Entities;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, RegisterUserCommand>().ReverseMap();
            CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
        }
    }
}
