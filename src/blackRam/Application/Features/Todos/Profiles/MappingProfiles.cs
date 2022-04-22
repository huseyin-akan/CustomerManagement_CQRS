using Application.Features.Todos.Commands.CreateTodoCommand;
using Application.Features.Todos.Commands.UpdateTodoCommand;
using Application.Features.Todos.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Todo, CreateTodoCommand>().ReverseMap();
            CreateMap<Todo, CreateTodoDto>().ReverseMap();
            CreateMap<Todo, UpdateTodoDto>().ReverseMap();
            CreateMap<Todo, UpdateTodoCommand>().ReverseMap();
        }
    }
}
