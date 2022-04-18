using Application.Features.CourtCases.Commands.CreateCourtCase;
using Application.Features.CourtCases.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CourtCases.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CourtCase, CreateCourtCaseCommand>().ReverseMap();
            CreateMap<CourtCase, CreateCourtCaseDto>().ReverseMap();
        }
    }
}
