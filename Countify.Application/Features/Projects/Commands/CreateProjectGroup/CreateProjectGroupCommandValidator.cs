using FluentValidation;

namespace Countify.Application.Features.Projects.Commands.CreateProjectGroup;

public class CreateProjectGroupCommandValidator : AbstractValidator<CreateProjectGroupCommand>
{
    public CreateProjectGroupCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}