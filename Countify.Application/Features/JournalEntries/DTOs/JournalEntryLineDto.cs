namespace Countify.Application.Features.JournalEntries.DTOs;

public class JournalEntryLineDto
{
    public Guid Id { get; set; }
    public Guid Gid { get; set; }
    public Guid AccountId { get; set; }
    public string AccountCode { get; set; } = null!;
    public string AccountName { get; set; } = null!;
    public Guid? DepartmentId { get; set; }
    public Guid? ProjectId { get; set; }
    public Guid? SubProjectId { get; set; }
    public int? EntryConceptType { get; set; }
    public string? Concept { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public Guid? AppliesToReceivableId { get; set; }
    public Guid? AppliesToPayableId { get; set; }
    public Guid? LoanCertificateId { get; set; }
    public Guid? FixedAssetMovementId { get; set; }
    public string? CustomerName { get; set; }
}