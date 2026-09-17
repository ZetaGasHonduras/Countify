using Countify.Application.Features.JournalEntries.DTOs;
using Countify.Domain.Enums;
using FluentValidation;

namespace Countify.Application.Features.JournalEntries.Commands.UpdateJournalEntry;

public class UpdateJournalEntryCommandValidator : AbstractValidator<UpdateJournalEntryCommand>
{
    public UpdateJournalEntryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.TypeId).NotEmpty();
        RuleFor(x => x.ReferenceDate).NotEmpty();
        RuleFor(x => x.Reference).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Concept).NotEmpty().MaximumLength(4000);
        RuleFor(x => x.Observations).MaximumLength(4000);
        RuleFor(x => x.Code).MaximumLength(20);
        RuleFor(x => x.Lines).NotEmpty();

        RuleForEach(x => x.Lines).ChildRules(lines =>
        {
            lines.RuleFor(l => l.AccountId).NotEmpty();
            lines.RuleFor(l => l.Debit).GreaterThanOrEqualTo(0);
            lines.RuleFor(l => l.Credit).GreaterThanOrEqualTo(0);
            lines.RuleFor(l => l.EntryConceptType)
                .Must(v => !v.HasValue || Enum.IsDefined(typeof(EntryConceptType), v.Value))
                .WithMessage("El tipo de concepto contable no es válido.");
            lines.RuleFor(l => l.Concept).MaximumLength(4000);
            lines.RuleFor(l => l.CustomerName).MaximumLength(200);
            lines.RuleFor(l => l)
                .Must(l => l.Debit == 0 || l.Credit == 0)
                .WithMessage("Una línea no puede tener débito y crédito a la vez.");
            lines.RuleFor(l => l)
                .Must(l => l.Debit > 0 || l.Credit > 0)
                .WithMessage("Cada línea debe tener débito o crédito mayor que cero.");
        });
    }
}