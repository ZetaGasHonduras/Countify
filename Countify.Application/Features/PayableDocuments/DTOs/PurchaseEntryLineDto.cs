namespace Countify.Application.Features.PayableDocuments.DTOs;

/// <summary>Línea del movimiento 'COM' de un Ingreso de Compras.</summary>
public class PurchaseEntryLineDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string? ProductCode { get; set; }
    public string? ProductName { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public Guid LocationId { get; set; }
    public string? LocationCode { get; set; }
    public string? LocationName { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public decimal TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal LineTotal { get; set; }
}
