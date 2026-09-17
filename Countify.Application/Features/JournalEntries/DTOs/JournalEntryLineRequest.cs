namespace Countify.Application.Features.JournalEntries.DTOs;

public class JournalEntryLineRequest
{
    public Guid AccountId { get; set; }
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