using FluentValidation;
using DemoOpenAPI.Requests;

namespace DemoOpenAPI.Validations;

public class UpdateBudgetRequestValidator : AbstractValidator<UpdateBudgetRequest>
{
    public UpdateBudgetRequestValidator()
    {
        RuleFor(x => x.Budget).GreaterThanOrEqualTo(0);
    }
}

