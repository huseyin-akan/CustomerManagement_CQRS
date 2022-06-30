using Application.Features.Todos.Rules;
using Application.Services.Repositories;
using Core.Application.Services;
using Core.Domain.Exceptions;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.DeleteTodoCommand
{
    public class DeleteTodoCommand : IRequest<Result>
    {
        public int Id { get; set; }
        
        public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, Result>
        {
            private readonly TodoBusinessRules _todoBusinessRules;
            private readonly ITodoRepository _todoRepository;
            private readonly ICurrentUserService _currentUserService;

            public DeleteTodoCommandHandler(
                TodoBusinessRules todoBusinessRules,
                ITodoRepository todoRepository,
                ICurrentUserService currentUserService)
            {
                _todoBusinessRules = todoBusinessRules;
                _todoRepository = todoRepository;
                _currentUserService = currentUserService;
            }

            public async Task<Result> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
            {
                var todoToUpdate = await _todoRepository.GetAsync(t => t.Id == request.Id);
                if (todoToUpdate is null)
                {
                    throw new NotFoundException(Messages.TodoNotFound); 
                }
                todoToUpdate.Status = false;

                var result = await _todoRepository.UpdateAsync(todoToUpdate);

                return new SuccessResult();
            }

        }
    }
}
