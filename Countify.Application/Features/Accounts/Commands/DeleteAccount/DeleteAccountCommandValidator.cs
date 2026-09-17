using FluentValidation;
using Countify.Application.Features.Accounts.Commands.DeleteAccount;

namespace Countify.Application.Features.Accounts.Commands.DeleteAccount;

public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
{
    public DeleteAccountCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}