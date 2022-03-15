using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Positions.Queries.QueryTopPositions
{
    public class GetTop7DaysPositionsQueryValidator : AbstractValidator<GetTop7DaysPositionsQuery>
    {
        public GetTop7DaysPositionsQueryValidator()
        {
            RuleFor(x => x.LimitPositions)
                .GreaterThan(0).WithMessage("Limit positions nedd to be greater than 0.")
                .LessThanOrEqualTo(10).WithMessage("Maximum limit positions is 10");

            RuleFor(x => (int)x.OperationType)
                .InclusiveBetween(-1, 1).WithMessage("Invalid operation value.")
                .NotEqual(0).WithMessage("Operation value can´t be 0.");
        }
    }
}
