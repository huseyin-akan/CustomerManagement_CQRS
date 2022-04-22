using Application.Features.Todos.Dtos;
using Application.Features.Todos.Rules;
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
            private readonly ITodoRepository _todoRepository;

            public CreateTodoCommandHandler(IMapper mapper,
                TodoBusinessRules todoBusinessRules,
                ITodoRepository todoRepository)
            {
                _mapper = mapper;
                _todoBusinessRules = todoBusinessRules;
                _todoRepository = todoRepository;
            }

            public async Task<CreateTodoDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
            {
                var todoToCreate = _mapper.Map<Todo>(request);
                todoToCreate.Done = false;

                var result = await _todoRepository.AddAsync(todoToCreate);

                return _mapper.Map<CreateTodoDto>(result);
            }

        }
    }
}
