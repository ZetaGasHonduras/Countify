using FluentValidation;

namespace Countify.Application.Features.AccountsReceivableDocuments.Commands.CreateAccountsReceivableDocument;

public class CreateAccountsReceivableDocumentCommandValidator : AbstractValidator<CreateAccountsReceivableDocumentCommand>
{
    public CreateAccountsReceivableDocumentCommandValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.ConceptId).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.DueDate).NotEmpty();
        RuleFor(x => x.CurrencyId).NotEmpty();
        RuleFor(x => x.ExchangeRate).GreaterThan(0);
        RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Reference).MaximumLength(100);
        RuleFor(x => x.AppliesTo).MaximumLength(50);
        RuleFor(x => x.Notes).MaximumLength(500);
    }
}