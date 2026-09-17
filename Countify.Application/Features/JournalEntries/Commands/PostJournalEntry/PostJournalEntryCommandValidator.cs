using FluentValidation;

namespace Countify.Application.Features.JournalEntries.Commands.PostJournalEntry;

public class PostJournalEntryCommandValidator : AbstractValidator<PostJournalEntryCommand>
{
    public PostJournalEntryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}