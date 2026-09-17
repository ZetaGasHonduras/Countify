using Countify.Domain.Entities.Accounting;
using Countify.Domain.Enums;

namespace Countify.Domain.Seeders;

public static class BasicJournalEntries
{
    public static readonly JournalEntryLine DebitLine = new()
    {
        Id = Guid.Parse("80000000-0000-0000-0000-000000000101"),
        AccountId = BasicAccounts.Cash.Id,
        DepartmentId = BasicDepartments.General.Id,
        ProjectId = BasicProjects.Central.Id,
        EntryConceptType = EntryConceptType.Debit,
        Concept = "Aporte inicial de caja",
        Debit = 1000m,
        Credit = 0m,
        LineGid = Guid.Parse("80000000-0000-0000-0000-000000000102")
    };

    public static readonly JournalEntryLine CreditLine = new()
    {
        Id = Guid.Parse("80000000-0000-0000-0000-000000000201"),
        AccountId = BasicAccounts.CapitalStock.Id,
        EntryConceptType = EntryConceptType.Credit,
        Concept = null,
        Debit = 0m,
        Credit = 1000m,
        LineGid = Guid.Parse("80000000-0000-0000-0000-000000000202")
    };

    public static readonly JournalEntry OpeningEntry = new()
    {
        Id = Guid.Parse("80000000-0000-0000-0000-000000000001"),
        EntryNumber = 1,
        Code = null,
        TypeId = BasicDocumentTypes.Partida.Id,
        PeriodId = BasicAccountingPeriods.Current.Id,
        ReferenceDate = DateTime.UtcNow,
        Reference = "APORTE-INICIAL",
        Concept = "Aporte de capital inicial",
        Observations = null,
        DebitTotal = 1000m,
        CreditTotal = 1000m,
        DifferenceAmount = 0m,
        Status = JournalEntryStatus.Posted,
        SourceModule = SourceModule.Manually,
        EntryGid = Guid.Parse("80000000-0000-0000-0000-000000000002"),
        Lines = [DebitLine, CreditLine]
    };

    public static JournalEntry[] Items { get; } = [OpeningEntry];
}