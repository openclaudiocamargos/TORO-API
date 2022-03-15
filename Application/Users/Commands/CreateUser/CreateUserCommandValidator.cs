using FluentValidation;

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
                .MinimumLength(4).WithMessage("First name too small.")
                .MaximumLength(30).WithMessage("First name too large.");

            RuleFor(x => x.LasttName)
                .NotEmpty().WithMessage("Last name not informed.")
                .MinimumLength(4).WithMessage("Last name too small.")
                .MaximumLength(30).WithMessage("Last name too large.");

            RuleFor(x => x.Document)
                .NotEmpty().WithMessage("Document not informed.")
                .MinimumLength(11).WithMessage("Document too small.")
                .MaximumLength(18).WithMessage("Documento too large.");
        }
    }
}
