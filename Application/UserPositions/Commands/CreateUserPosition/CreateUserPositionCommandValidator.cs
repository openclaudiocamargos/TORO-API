using FluentValidation;

namespace Application.UserPositions.Commands.CreateUserPosition
{
    public class CreateUserPositionCommandValidator : AbstractValidator<CreateUserPositionCommand>
    {
        public CreateUserPositionCommandValidator()
        {
            RuleFor(x => x.Symbol)
                .NotEmpty().WithMessage("Invalid symbol.")
                .MaximumLength(10).WithMessage("Invalid symbol.");
        }
    }
}
