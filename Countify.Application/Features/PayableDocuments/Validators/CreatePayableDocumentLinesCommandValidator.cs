using Countify.Application.Features.PayableDocuments.Commands.CreatePayableDocumentLines;
using FluentValidation;

namespace Countify.Application.Features.PayableDocuments.Validators;

public class CreatePayableDocumentLinesCommandValidator
    : AbstractValidator<CreatePayableDocumentLinesCommand>
{
    public CreatePayableDocumentLinesCommandValidator()
    {
        RuleFor(x => x.DocumentId)
            .NotEmpty();

        RuleFor(x => x.Lines)
            .NotEmpty()
            .WithMessage("Debe seleccionar al menos una factura para aplicar.");

        RuleForEach(x => x.Lines)
            .ChildRules(lines =>
            {
                lines.RuleFor(l => l.AppliedDocumentId)
                    .NotEmpty();

                lines.When(l => l.Amount.HasValue, () =>
                {
                    lines.RuleFor(l => l.Amount!.Value)
                        .GreaterThan(0)
                        .WithMessage("El abono debe ser mayor que cero.");
                });
            });
    }
}
