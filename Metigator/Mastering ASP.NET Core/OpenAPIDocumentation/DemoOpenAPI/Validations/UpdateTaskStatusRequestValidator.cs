using FluentValidation;
using DemoOpenAPI.Requests;

namespace DemoOpenAPI.Validations;

public class UpdateTaskStatusRequestValidator : AbstractValidator<UpdateTaskStatusRequest>
{
    public UpdateTaskStatusRequestValidator()
    {
        RuleFor(x => x.Status).IsInEnum();
    }
}

