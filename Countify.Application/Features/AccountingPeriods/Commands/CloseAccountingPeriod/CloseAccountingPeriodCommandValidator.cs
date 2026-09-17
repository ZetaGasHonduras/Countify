using FluentValidation;

namespace Countify.Application.Features.AccountingPeriods.Commands.CloseAccountingPeriod;

public class CloseAccountingPeriodCommandValidator : AbstractValidator<CloseAccountingPeriodCommand>
{
    public CloseAccountingPeriodCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}