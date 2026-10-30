using FluentValidation;
using DemoOpenAPI.Requests;

namespace DemoOpenAPI.Validations;

public class CreateProjectRequestValidator : AbstractValidator<CreateProjectRequest>
{
    public CreateProjectRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);
        RuleFor(x => x.ExpectedStartDate).GreaterThan(DateTime.MinValue);
        RuleFor(x => x.Budget).GreaterThanOrEqualTo(0);
    }
}