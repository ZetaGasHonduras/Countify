using Countify.Domain.Entities.AccountsPayable;

namespace Countify.Application.Features.PayableConcepts.DTOs;

public class PayableConceptDto
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public PayableConceptType Type { get; set; }
    public string? TypeName { get; set; }
    public Guid? AccountId { get; set; }
    public string? AccountCode { get; set; }
    public string? AccountName { get; set; }
    public bool IsInactive { get; set; }
    public bool GeneratePosting { get; set; }
    public bool IsPayment { get; set; }
    public string? Observations { get; set; }
}
