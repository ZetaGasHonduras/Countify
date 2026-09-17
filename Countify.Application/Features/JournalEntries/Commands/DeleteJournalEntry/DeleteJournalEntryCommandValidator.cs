using FluentValidation;

namespace Countify.Application.Features.JournalEntries.Commands.DeleteJournalEntry;

public class DeleteJournalEntryCommandValidator : AbstractValidator<DeleteJournalEntryCommand>
{
    public DeleteJournalEntryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}