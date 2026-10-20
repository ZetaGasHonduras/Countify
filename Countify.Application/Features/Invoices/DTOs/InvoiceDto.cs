namespace Countify.Application.Features.Invoices.DTOs;

public class InvoiceDto
{
    public Guid Id { get; set; }
    public string? Number { get; set; }
    public int Correlativo { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerCode { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string? CustomerTaxId { get; set; }
    public string? CustomerAddress { get; set; }
    public string? CustomerPhone { get; set; }

    /// <summary>1 = Contado, 2 = Crédito (valores del legacy).</summary>
    public int PaymentTerms { get; set; }

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string? Reference { get; set; }
    public string? OrderNumber { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public Guid? ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public Guid CurrencyId { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public decimal ExchangeRate { get; set; }

    public bool IsTaxExempt { get; set; }
    public bool IsExonerated { get; set; }

    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal DiscountTotal { get; set; }
    public decimal SubTotalExempt { get; set; }
    public decimal Total { get; set; }
    public decimal TotalLocal { get; set; }

    public string? Notes { get; set; }
    public bool IsPrinted { get; set; }
    public DateTime? PrintedAt { get; set; }
    public bool IsVoided { get; set; }
    public DateTime? VoidedAt { get; set; }
    public string? VoidReason { get; set; }

    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public DateTime? EmissionLimitDate { get; set; }

    public Guid? ReceivableDocumentId { get; set; }
    public int? ReceivableDocumentNo { get; set; }

    public List<InvoiceLineDto> Lines { get; set; } = [];
}
