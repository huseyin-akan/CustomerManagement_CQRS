using Application.Features.Todos.Dtos;
using Application.Features.Todos.Rules;
using Application.Helpers;
using Application.Services;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.Application.Services;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.CreateTodoCommand
{    
    public class CreateTodoCommand : IRequest<CreateTodoDto>, ILoggableRequest
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime? ExpirationDate { get; set; }
        public int CourtCaseId { get; set; }

        public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreateTodoDto>
        {
            private readonly IMapper _mapper;
            private readonly TodoBusinessRules _todoBusinessRules;
            private readonly ITodoRepository _courtCaseRepository;
            private readonly ICurrentUserService _currentUserService;

            public CreateTodoCommandHandler(IMapper mapper,
                TodoBusinessRules todoBusinessRules,
                ITodoRepository courtCaseRepository, ICurrentUserService currentUserService)
            {
                _mapper = mapper;
                _todoBusinessRules = todoBusinessRules;
                _courtCaseRepository = courtCaseRepository;
                _currentUserService = currentUserService;
            }

            public async Task<CreateTodoDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
            {
                var todoToCreate = _mapper.Map<Todo>(request);
                todoToCreate.Done = false;
                todoToCreate = CurrentUserHelper<Todo>.HandleCreateCommand(todoToCreate, _currentUserService);

                var result = await this._courtCaseRepository.AddAsync(todoToCreate);

                return this._mapper.Map<CreateTodoDto>(result);
            }

        }
    }
}
