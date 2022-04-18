using Application.Features.CourtCases.Dtos;
using Application.Features.CourtCases.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CourtCases.Commands.CreateCourtCase
{
    public class CreateCourtCaseCommand : IRequest<CreateCourtCaseDto>
    {
        public string Name { get; set; } = "";
             

        public class CreateCourtCaseCommandHandler : IRequestHandler<CreateCourtCaseCommand, CreateCourtCaseDto>
        {
            private readonly IMapper _mapper;
            private readonly CourtCaseBusinessRules _courtCaseBusinessRules;
            private readonly ICourtCaseRepository _courtCaseRepository;

            public CreateCourtCaseCommandHandler(
                IMapper mapper,
                CourtCaseBusinessRules courtCaseBusinessRules,
                ICourtCaseRepository courtCaseRepository)
            {
                _mapper = mapper;
                _courtCaseBusinessRules = courtCaseBusinessRules;
                _courtCaseRepository = courtCaseRepository;
            }
            public async Task<CreateCourtCaseDto> Handle(CreateCourtCaseCommand request, CancellationToken cancellationToken)
            {
                var caseToCreate = _mapper.Map<CourtCase>(request);
                caseToCreate.CreatedDate = DateTime.Now;
                caseToCreate.CaseStatus = CaseStatus.Open;

                var result = await this._courtCaseRepository.AddAsync(caseToCreate);

                return this._mapper.Map<CreateCourtCaseDto>(result);
            }

        }
    }

}
