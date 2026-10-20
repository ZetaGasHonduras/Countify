using FluentValidation;

namespace Countify.Application.Features.SupplierTypes.Commands.UpdateSupplierType;

public class UpdateSupplierTypeCommandValidator : AbstractValidator<UpdateSupplierTypeCommand>
{
    public UpdateSupplierTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
