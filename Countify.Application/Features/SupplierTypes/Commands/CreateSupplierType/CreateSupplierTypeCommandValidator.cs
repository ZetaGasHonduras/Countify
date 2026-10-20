using FluentValidation;

namespace Countify.Application.Features.SupplierTypes.Commands.CreateSupplierType;

public class CreateSupplierTypeCommandValidator : AbstractValidator<CreateSupplierTypeCommand>
{
    public CreateSupplierTypeCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
