using Countify.Application.Features.AccountsReceivableDocuments.Commands.CreateAccountsReceivableDocumentLines;
using FluentValidation;

namespace Countify.Application.Features.AccountsReceivableDocuments.Validators;

public class CreateAccountsReceivableDocumentLinesCommandValidator
    : AbstractValidator<CreateAccountsReceivableDocumentLinesCommand>
{
    public CreateAccountsReceivableDocumentLinesCommandValidator()
    {
        RuleFor(x => x.DocumentId)
            .NotEmpty();

        RuleFor(x => x.Lines)
            .NotEmpty()
            .WithMessage("Debe seleccionar al menos un documento para aplicar.");

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