using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Commands.CreateTodoCommand
{
    public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator() 
        {
            RuleFor(t => t.Title).NotNull().NotEmpty().WithMessage("Başlık kısmı boş bırakılamaz");
            RuleFor(t => t.Description).NotNull().NotEmpty().WithMessage("Not kısmı boş bırakılamaz");
            RuleFor(t => t.ExpirationDate).GreaterThan(DateTime.Now).WithMessage("Görev tamamlanma tarihi geçmişte bitemez.");
            RuleFor(t => t.CourtCaseId).NotNull().NotEmpty().WithMessage("Mahkeme seçimi boş bırakılamaz");
        }
    }
    
}
