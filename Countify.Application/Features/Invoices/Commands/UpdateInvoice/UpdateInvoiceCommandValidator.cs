using Countify.Application.Features.Invoices.Commands.CreateInvoice;
using FluentValidation;

namespace Countify.Application.Features.Invoices.Commands.UpdateInvoice;

public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
{
    public UpdateInvoiceCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.CurrencyId).NotEmpty();
        RuleFor(x => x.ExchangeRate).GreaterThan(0);
        RuleFor(x => x.Reference).MaximumLength(100);
        RuleFor(x => x.OrderNumber).MaximumLength(50);
        RuleFor(x => x.Notes).MaximumLength(500);

        RuleFor(x => x.Lines)
            .NotEmpty().WithMessage("La factura debe tener al menos una línea.")
            .Must(lines => lines.Count <= 28).WithMessage("No se puede facturar más de 28 líneas.");

        RuleForEach(x => x.Lines).ChildRules(line =>
        {
            line.RuleFor(l => l.Description).NotEmpty().MaximumLength(300);
            line.RuleFor(l => l.Quantity).GreaterThan(0);
            line.RuleFor(l => l.UnitPrice).GreaterThanOrEqualTo(0);
            line.RuleFor(l => l.DiscountPercent).InclusiveBetween(0, 100);
            line.RuleFor(l => l.TaxRate).InclusiveBetween(0, 100);
        });
    }
}
