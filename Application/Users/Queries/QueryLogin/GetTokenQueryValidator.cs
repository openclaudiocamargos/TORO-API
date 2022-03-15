using FluentValidation;

namespace Application.Users.Queries.QueryLogin
{
    public class GetTokenQueryValidator : AbstractValidator<GetTokenQuery>
    {
        public GetTokenQueryValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login not informed.")
                .MinimumLength(4).WithMessage("Invalid login value.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password not informed.")
                .MinimumLength(4).WithMessage("Invalid password value.");
        }
    }
}
