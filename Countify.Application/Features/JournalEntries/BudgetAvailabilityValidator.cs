using Countify.Application.Features.JournalEntries.DTOs;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.JournalEntries;

internal static class BudgetAvailabilityValidator
{
    public static async Task<string?> ValidateAsync(
        IUnitOfWork unitOfWork,
        IEnumerable<JournalEntryLineRequest> requestedLines,
        DateTime referenceDate,
        Guid? excludedEntryId,
        CancellationToken cancellationToken)
    {
        var lines = requestedLines.Where(line => line.Debit > 0).ToList();
        if (lines.Count == 0) return null;

        var budgets = await unitOfWork.Budgets.Query()
            .Include(b => b.Lines)
            .Where(b => b.FiscalYear == referenceDate.Year)
            .ToListAsync(cancellationToken);

        if (budgets.Count == 0) return null;

        var existingLines = await unitOfWork.JournalEntryLines.Query()
            .Include(line => line.JournalEntry)
            .Where(line => line.JournalEntry != null &&
                           line.JournalEntry.ReferenceDate.Year == referenceDate.Year &&
                           line.JournalEntry.ReferenceDate.Month == referenceDate.Month &&
                           line.JournalEntry.Status != JournalEntryStatus.Voided &&
                           (!excludedEntryId.HasValue || line.JournalEntryId != excludedEntryId.Value))
            .ToListAsync(cancellationToken);

        var groupedLines = lines.GroupBy(line => new { line.AccountId, line.DepartmentId, line.ProjectId });
        foreach (var group in groupedLines)
        {
            var budgetLines = budgets.SelectMany(b => b.Lines).Where(line =>
                line.AccountId == group.Key.AccountId && line.DepartmentId == group.Key.DepartmentId && line.ProjectId == group.Key.ProjectId).ToList();
            if (budgetLines.Count == 0) continue;

            var consumed = existingLines
                .Where(line => line.AccountId == group.Key.AccountId && line.DepartmentId == group.Key.DepartmentId && line.ProjectId == group.Key.ProjectId)
                .Sum(line => line.Debit);
            var requestedAmount = group.Sum(line => line.Debit);
            var available = referenceDate.Month switch
            {
                1 => budgetLines.Sum(line => line.January),
                2 => budgetLines.Sum(line => line.February),
                3 => budgetLines.Sum(line => line.March),
                4 => budgetLines.Sum(line => line.April),
                5 => budgetLines.Sum(line => line.May),
                6 => budgetLines.Sum(line => line.June),
                7 => budgetLines.Sum(line => line.July),
                8 => budgetLines.Sum(line => line.August),
                9 => budgetLines.Sum(line => line.September),
                10 => budgetLines.Sum(line => line.October),
                11 => budgetLines.Sum(line => line.November),
                _ => budgetLines.Sum(line => line.December)
            };

            if (consumed + requestedAmount > available)
                return $"La partida excede el presupuesto disponible para la cuenta y dimensión seleccionadas ({available - consumed:0.00} disponible).";
        }

        return null;
    }
}
