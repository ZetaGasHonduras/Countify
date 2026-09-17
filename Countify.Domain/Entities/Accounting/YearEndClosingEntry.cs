using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class YearEndClosingEntry : BaseEntity
{
    public Guid PeriodId { get; set; }
    public Guid JournalEntryId { get; set; }
    public string? GeneratedBy { get; set; }
}