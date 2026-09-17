using FluentValidation;

namespace Countify.Application.Features.AccountingPeriods.Commands.CreateAccountingPeriod;

public class CreateAccountingPeriodCommandValidator : AbstractValidator<CreateAccountingPeriodCommand>
{
    public CreateAccountingPeriodCommandValidator()
    {
        RuleFor(x => x.Month).NotEmpty();
    }
}