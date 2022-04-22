using Application.Features.Todos.Dtos;
using Application.Features.Todos.Rules;
using Application.Helpers;
using Application.Services;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Services;
using Core.Domain.Exceptions;
using Core.Utilities.Messages;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.UpdateTodoCommand
{    
    public class UpdateTodoCommand : IRequest<UpdateTodoDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int CourtCaseId { get; set; }
        public bool Done { get; set; }

        public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, UpdateTodoDto>
        {
            private readonly IMapper _mapper;
            private readonly TodoBusinessRules _todoBusinessRules;
            private readonly ITodoRepository _courtCaseRepository;
            private readonly ICurrentUserService _currentUserService;

            public UpdateTodoCommandHandler(IMapper mapper,
                TodoBusinessRules todoBusinessRules,
                ITodoRepository courtCaseRepository, ICurrentUserService currentUserService)
            {
                _mapper = mapper;
                _todoBusinessRules = todoBusinessRules;
                _courtCaseRepository = courtCaseRepository;
                _currentUserService = currentUserService;
            }

            public async Task<UpdateTodoDto> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
            {
                var todoToUpdate = await _courtCaseRepository.GetAsync(t => t.Id == request.Id);
                if (todoToUpdate is null)
                {
                    throw new NotFoundException(Messages.TodoNotFound);
                }
                var mappedTodo = _mapper.Map(request, todoToUpdate);
                //mappedTodo = CurrentUserHelper<Todo>.HandleUpdateCommand(mappedTodo, _currentUserService);                

                var result = await _courtCaseRepository.UpdateAsync(mappedTodo);

                return _mapper.Map<UpdateTodoDto>(result);
            }

        }
    }
}
