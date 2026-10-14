using FluentValidation;

namespace Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType;

public class UpdateCustomerTypeCommandValidator : AbstractValidator<UpdateCustomerTypeCommand>
{
    public UpdateCustomerTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}