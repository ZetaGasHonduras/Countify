namespace Countify.Application.Features.Invoices.DTOs;

public class InvoiceLineDto
{
    public Guid Id { get; set; }
    public Guid? ProductId { get; set; }
    public string? Code { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal DiscountPercent { get; set; }
    public decimal DiscountAmount { get; set; }
    public bool IsTaxable { get; set; }
    public decimal TaxRate { get; set; }
    public decimal LineTotal { get; set; }
    public string? Notes { get; set; }
    public int Order { get; set; }
}
