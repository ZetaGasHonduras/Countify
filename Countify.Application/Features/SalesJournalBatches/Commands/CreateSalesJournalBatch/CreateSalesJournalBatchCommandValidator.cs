using FluentValidation;

namespace Countify.Application.Features.SalesJournalBatches.Commands.CreateSalesJournalBatch;

public class CreateSalesJournalBatchCommandValidator : AbstractValidator<CreateSalesJournalBatchCommand>
{
    public CreateSalesJournalBatchCommandValidator()
    {
        RuleFor(x => x.PeriodFrom).NotEmpty();
        RuleFor(x => x.PeriodTo).NotEmpty();
        RuleFor(x => x.Notes).MaximumLength(500);
    }
}
