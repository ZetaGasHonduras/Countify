using FluentValidation;

namespace Countify.Application.Features.CustomerTypes.Commands.CreateCustomerType;

public class CreateCustomerTypeCommandValidator : AbstractValidator<CreateCustomerTypeCommand>
{
    public CreateCustomerTypeCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}