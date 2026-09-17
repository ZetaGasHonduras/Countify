using FluentValidation;

namespace Countify.Application.Features.AccountingPeriods.Commands.DeleteAccountingPeriod;

public class DeleteAccountingPeriodCommandValidator : AbstractValidator<DeleteAccountingPeriodCommand>
{
    public DeleteAccountingPeriodCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}