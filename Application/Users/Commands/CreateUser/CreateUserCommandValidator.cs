using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login not informed.")
                .MinimumLength(4).WithMessage("Invalid login value.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password not informed.")
                .MinimumLength(4).WithMessage("Invalid password value.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name not informed.")
                .MinimumLength(4).WithMessage("Invalid first name value.");

            RuleFor(x => x.LasttName)
                .NotEmpty().WithMessage("Last name not informed.")
                .MinimumLength(4).WithMessage("Invalid last name value.");
        }
    }
}
