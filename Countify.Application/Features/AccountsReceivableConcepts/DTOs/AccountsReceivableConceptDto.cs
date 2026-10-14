using Countify.Domain.Entities.AccountsReceivable;

namespace Countify.Application.Features.AccountsReceivableConcepts.DTOs;

public class AccountsReceivableConceptDto
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public AccountsReceivableConceptType Type { get; set; }
    public string? TypeName { get; set; }
    public Guid? AccountId { get; set; }
    public string? AccountCode { get; set; }
    public string? AccountName { get; set; }
    public bool IsInactive { get; set; }
    public bool GeneratePosting { get; set; }
    public string? Observations { get; set; }
}