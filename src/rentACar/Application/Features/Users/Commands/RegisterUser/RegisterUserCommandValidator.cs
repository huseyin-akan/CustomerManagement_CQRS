using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(c => c.Username).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz.");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Şifre alanı adı boş bırakılamaz."); ;
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz."); ;
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Password).Length(6,20).WithMessage("Şifre en az 6-20 karakter arası olmalıdır."); ;
        }
    }
}
