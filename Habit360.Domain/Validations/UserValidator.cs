using FluentValidation;
using Habit360.Domain.Models;

namespace Habit360.Domain.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O nome precisa ser preenchido")
                .Length(2, 40);

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O email precisa ser preenchido")
                .EmailAddress().WithMessage("O email deve ser um endereço válido.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("A senha precisa ser preenchida")
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número.")
                .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial.");
        }
    }
}

