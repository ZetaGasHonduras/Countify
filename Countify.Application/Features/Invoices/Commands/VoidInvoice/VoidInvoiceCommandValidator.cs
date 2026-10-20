using FluentValidation;

namespace Countify.Application.Features.Invoices.Commands.VoidInvoice;

public class VoidInvoiceCommandValidator : AbstractValidator<VoidInvoiceCommand>
{
    public VoidInvoiceCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Reason).NotEmpty().MaximumLength(500)
            .WithMessage("El motivo de anulación es obligatorio.");
    }
}
