using FluentValidation;

namespace Countify.Application.Features.JournalEntries.Commands.ApproveJournalEntry;

public class ApproveJournalEntryCommandValidator : AbstractValidator<ApproveJournalEntryCommand>
{
    public ApproveJournalEntryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}