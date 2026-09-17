using Countify.Domain.Common;
using Countify.Domain.Enums;

namespace Countify.Domain.Entities.Accounting;

public class JournalEntry : BaseEntity
{
    public int EntryNumber { get; set; }
    public string? Code { get; set; }
    public Guid TypeId { get; set; }
    public DocumentType? Type { get; set; }
    public Guid? PeriodId { get; set; }
    public AccountingPeriod? Period { get; set; }
    public DateTime ReferenceDate { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string Concept { get; set; } = string.Empty;
    public string? Observations { get; set; }
    public decimal DebitTotal { get; set; }
    public decimal CreditTotal { get; set; }
    public decimal DifferenceAmount { get; set; }
    public JournalEntryStatus Status { get; set; } = JournalEntryStatus.Draft;
    public SourceModule SourceModule { get; set; } = SourceModule.Manually;
    public Guid EntryGid { get; set; }
    public List<JournalEntryLine> Lines { get; set; } = [];
}