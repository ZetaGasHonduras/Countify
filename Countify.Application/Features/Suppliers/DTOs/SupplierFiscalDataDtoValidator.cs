using Countify.Application.Features.Suppliers.DTOs;
using FluentValidation;

namespace Countify.Application.Features.Suppliers.DTOs;

public class SupplierFiscalDataDtoValidator : AbstractValidator<SupplierFiscalDataDto>
{
    public SupplierFiscalDataDtoValidator()
    {
        RuleFor(x => x.Branch).MaximumLength(100);
        RuleFor(x => x.CAI).MaximumLength(100);
        RuleFor(x => x.RangeFrom).MaximumLength(50);
        RuleFor(x => x.RangeTo).MaximumLength(50);
        RuleFor(x => x.Correlative).MaximumLength(50);
    }
}
