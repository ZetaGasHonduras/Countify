using FluentValidation;

namespace Countify.Application.Features.Invoices.Commands.SetInvoicePayments;

public class SetInvoicePaymentsCommandValidator : AbstractValidator<SetInvoicePaymentsCommand>
{
    public SetInvoicePaymentsCommandValidator()
    {
        RuleFor(x => x.InvoiceId).NotEmpty();
        RuleFor(x => x.Payments).NotEmpty().WithMessage("Agregue al menos un pago.");

        RuleForEach(x => x.Payments).ChildRules(payment =>
        {
            payment.RuleFor(p => p.PaymentMethodId).NotEmpty();
            payment.RuleFor(p => p.Amount).GreaterThan(0)
                .WithMessage("Cada pago debe ser mayor que cero.");
        });
    }
}
