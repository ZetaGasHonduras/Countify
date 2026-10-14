using FluentValidation;

namespace Countify.Application.Features.AccountsReceivableConcepts.Commands.CreateAccountsReceivableConcept;

public class CreateAccountsReceivableConceptCommandValidator : AbstractValidator<CreateAccountsReceivableConceptCommand>
{
    public CreateAccountsReceivableConceptCommandValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Observations).MaximumLength(500);
    }
}