using Countify.Application.Features.Suppliers.DTOs;
using FluentValidation;

namespace Countify.Application.Features.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.TaxId).MaximumLength(20);
        RuleFor(x => x.IdentityDocument).MaximumLength(20);
        RuleFor(x => x.Registration).MaximumLength(50);
        RuleFor(x => x.Email).MaximumLength(100);
        RuleFor(x => x.Phone).MaximumLength(30);
        RuleFor(x => x.Fax).MaximumLength(30);
        RuleFor(x => x.Address).MaximumLength(300);
        RuleFor(x => x.City).MaximumLength(100);
        RuleFor(x => x.ContactName).MaximumLength(150);
        RuleFor(x => x.ContactPosition).MaximumLength(100);
        RuleFor(x => x.ContactPhone).MaximumLength(30);
        RuleFor(x => x.ContactEmail).MaximumLength(100);
        RuleFor(x => x.CreditLimit).GreaterThanOrEqualTo(0);
        RuleForEach(x => x.FiscalData).SetValidator(new SupplierFiscalDataDtoValidator());
    }
}
