using FluentValidation;
using DemoOpenAPI.Requests;

namespace DemoOpenAPI.Validations;

public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);
        RuleFor(x => x.AssignedUserId).NotEmpty();
    }
}

