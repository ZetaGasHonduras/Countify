namespace Countify.Application.Features.PayableDocuments.DTOs;

public class PayableDocumentLineDto
{
    public Guid Id { get; set; }
    public Guid DocumentId { get; set; }
    public Guid AppliedDocumentId { get; set; }
    public int AppliedDocumentNo { get; set; }
    public string? AppliedReference { get; set; }
    public string AppliedConcept { get; set; } = string.Empty;
    public DateTime AppliedDate { get; set; }
    public string AppliedCurrencyCode { get; set; } = string.Empty;
    public decimal AppliedAmount { get; set; }
    public decimal AppliedOutstandingAmount { get; set; }
    public decimal Amount { get; set; }
}
