using FluentValidation;

namespace Countify.Application.Features.PayableDocuments.Commands.UpdatePayableDocument;

public class UpdatePayableDocumentCommandValidator : AbstractValidator<UpdatePayableDocumentCommand>
{
    public UpdatePayableDocumentCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.SupplierId).NotEmpty();
        RuleFor(x => x.ConceptId).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.DueDate).NotEmpty();
        RuleFor(x => x.CurrencyId).NotEmpty();
        RuleFor(x => x.ExchangeRate).GreaterThan(0);
        RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Tax).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Reference).MaximumLength(100);
        RuleFor(x => x.AppliesTo).MaximumLength(50);
        RuleFor(x => x.Notes).MaximumLength(500);
    }
}
