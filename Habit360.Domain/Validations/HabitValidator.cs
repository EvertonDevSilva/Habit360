using FluentValidation;
using Habit360.Domain.Models;

namespace Habit360.Domain.Validations
{
    public class HabitValidator : AbstractValidator<Habit>
    {
        public HabitValidator()
        {
            RuleFor(habit => habit.Name)
                .NotEmpty().WithMessage("O nome precisa ser preenchido")
                .Length(2, 20).WithMessage("O nome ter entre 2 e 40 caracteres");

            RuleFor(habit => habit.Description)
                 .Length(2, 50).WithMessage("A descrição precisa ter entre 2 e 50 caracteres");

            RuleFor(habit => habit.HabitType)
                .NotEmpty().WithMessage("O tipo de hábito precisa ser preenchido");

            RuleFor(habit => habit.StartDate)
                .NotNull().WithMessage("A data de início precisa ser preenchido")
                .Must(BeAValidDate).WithMessage("A data não é válida.")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("A data do deve ser no futuro.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default);
        }
    }
}
