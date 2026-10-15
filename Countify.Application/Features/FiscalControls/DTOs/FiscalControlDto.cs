using Countify.Domain.Enums;

namespace Countify.Application.Features.FiscalControls.DTOs;

public class FiscalControlDto
{
    public Guid Id { get; set; }
    public FiscalDocumentType DocumentType { get; set; }
    public string DocumentTypeName { get; set; } = string.Empty;
    public string? Branch { get; set; }
    public string? EmissionPoint { get; set; }
    public string? DocumentCode { get; set; }
    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public DateTime? EmissionDate { get; set; }
    public DateTime? EmissionLimitDate { get; set; }
    public bool IsActive { get; set; }
    public int LastNumber { get; set; }
    public int WarningNumber { get; set; }
    public string? Observations { get; set; }
}
