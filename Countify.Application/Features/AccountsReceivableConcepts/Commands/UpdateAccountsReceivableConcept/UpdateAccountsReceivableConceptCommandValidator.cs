using FluentValidation;

namespace Countify.Application.Features.AccountsReceivableConcepts.Commands.UpdateAccountsReceivableConcept;

public class UpdateAccountsReceivableConceptCommandValidator : AbstractValidator<UpdateAccountsReceivableConceptCommand>
{
    public UpdateAccountsReceivableConceptCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Observations).MaximumLength(500);
    }
}