using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicYearEndClosingEntries
{
    public static readonly YearEndClosingEntry MonthlyClosing = new()
    {
        Id = Guid.Parse("82000000-0000-0000-0000-000000000001"),
        PeriodId = BasicAccountingPeriods.LastMonth.Id,
        JournalEntryId = BasicJournalEntries.OpeningEntry.Id,
        GeneratedBy = BasicUsers.SuperAdmin.UserName
    };

    public static YearEndClosingEntry[] Items { get; } = [MonthlyClosing];
}