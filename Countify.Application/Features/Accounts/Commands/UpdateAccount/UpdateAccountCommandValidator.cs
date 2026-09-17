using FluentValidation;

namespace Countify.Application.Features.Accounts.Commands.UpdateAccount;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.ParentCode).MaximumLength(20);
        RuleFor(x => x.Level).GreaterThanOrEqualTo(0);
        RuleFor(x => x.BudgetLine).MaximumLength(255);
    }
}