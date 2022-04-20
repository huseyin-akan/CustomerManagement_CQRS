using Application.Features.Todos.Dtos;
using Application.Features.Todos.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.CreateTodoCommand
{    
    public class CreateTodoCommand : IRequest<CreateTodoDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int CourtCaseId { get; set; }

        public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreateTodoDto>
        {
            private readonly IMapper _mapper;
            private readonly TodoBusinessRules _todoBusinessRules;
            private readonly ITodoRepository _courtCaseRepository;

            public CreateTodoCommandHandler(IMapper mapper,
                TodoBusinessRules todoBusinessRules,
                ITodoRepository courtCaseRepository)
            {
                _mapper = mapper;
                _todoBusinessRules = todoBusinessRules;
                _courtCaseRepository = courtCaseRepository;
            }

            public async Task<CreateTodoDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
            {
                var todoToCreate = _mapper.Map<Todo>(request);
                //TODO: Todo oluşturan kişiyi burada mı ekleyelim? //CreatedBy vs. zımbırtıları için diyorum.

                var result = await this._courtCaseRepository.AddAsync(todoToCreate);

                return this._mapper.Map<CreateTodoDto>(result);
            }

        }
    }
}
