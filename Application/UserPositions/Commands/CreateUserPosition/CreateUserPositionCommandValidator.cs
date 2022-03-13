using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserPositions.Commands.CreateUserPosition
{
    public class CreateUserPositionCommandValidator : AbstractValidator<CreateUserPositionCommand>
    {
        public CreateUserPositionCommandValidator()
        {
            RuleFor(x => x.Symbol)
                .NotEmpty().WithMessage("Invalid symbol.")
                .Length(5).WithMessage("Invalid symbol.");
        }
    }
}
