using Application.Features.CourtCases.Dtos;
using Application.Features.CourtCases.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Services;
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
        public string CaseNumber { get; set; }
        public int CourtId { get; set; }

        public class CreateCourtCaseCommandHandler : IRequestHandler<CreateCourtCaseCommand, CreateCourtCaseDto>
        {
            private readonly IMapper _mapper;
            private readonly CourtCaseBusinessRules _courtCaseBusinessRules;
            private readonly ICourtCaseRepository _courtCaseRepository;
            private readonly ICurrentUserService _currentUserService;

            public CreateCourtCaseCommandHandler(
                IMapper mapper,
                CourtCaseBusinessRules courtCaseBusinessRules,
                ICourtCaseRepository courtCaseRepository, ICurrentUserService currentUserService)
            {
                _mapper = mapper;
                _courtCaseBusinessRules = courtCaseBusinessRules;
                _courtCaseRepository = courtCaseRepository;
                _currentUserService = currentUserService;
            }
            public async Task<CreateCourtCaseDto> Handle(CreateCourtCaseCommand request, CancellationToken cancellationToken)
            {
                var caseToCreate = _mapper.Map<CourtCase>(request);
                //TODO: check if this line of code is necessary, because we anyway have it in the constructor. and lets try a few more cont
                //constructral issues.
                caseToCreate.CaseStatus = CaseStatus.Open;

                var result = await this._courtCaseRepository.AddAsync(caseToCreate);

                return this._mapper.Map<CreateCourtCaseDto>(result);
            }

        }
    }

}
