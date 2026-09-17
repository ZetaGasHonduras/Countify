using FluentValidation;

namespace Countify.Application.Features.JournalEntries.Commands.VoidJournalEntry;

public class VoidJournalEntryCommandValidator : AbstractValidator<VoidJournalEntryCommand>
{
    public VoidJournalEntryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}