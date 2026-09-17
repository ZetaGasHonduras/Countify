using Countify.Domain.Common;
using Countify.Domain.Enums;

namespace Countify.Domain.Entities.Accounting;

public class JournalEntryLine : BaseEntity
{
    public Guid JournalEntryId { get; set; }
    public JournalEntry? JournalEntry { get; set; }

    public Guid AccountId { get; set; }
    public Account? Account { get; set; }

    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public Guid? ProjectId { get; set; }
    public Project? Project { get; set; }

    public Guid? SubProjectId { get; set; }

    public EntryConceptType? EntryConceptType { get; set; }

    public string? Concept { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }

    public Guid? AppliesToReceivableId { get; set; }
    public Guid? AppliesToPayableId { get; set; }
    public Guid? LoanCertificateId { get; set; }
    public Guid? FixedAssetMovementId { get; set; }
    public string? CustomerName { get; set; }

    public Guid LineGid { get; set; }
}