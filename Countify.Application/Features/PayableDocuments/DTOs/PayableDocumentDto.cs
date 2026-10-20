namespace Countify.Application.Features.PayableDocuments.DTOs;

public class PayableDocumentDto
{
    public Guid Id { get; set; }
    public int DocumentNo { get; set; }
    public Guid SupplierId { get; set; }
    public string SupplierCode { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
    public Guid ConceptId { get; set; }
    public string ConceptDescription { get; set; } = string.Empty;

    /// <summary>El documento es un pago/abono (concepto Credit(2) del legacy).</summary>
    public bool IsPayment { get; set; }

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string? Reference { get; set; }
    public string? AppliesTo { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public Guid? ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public Guid CurrencyId { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public decimal ExchangeRate { get; set; }
    public decimal Amount { get; set; }
    public decimal Tax { get; set; }
    public decimal TaxLocal { get; set; }
    public decimal AmountLocal { get; set; }

    /// <summary>Total = Amount + Tax.</summary>
    public decimal Total { get; set; }

    /// <summary>Total en moneda local = AmountLocal + TaxLocal.</summary>
    public decimal TotalLocal { get; set; }

    /// <summary>Saldo pendiente (compras no anuladas: Total - Σ abonos aplicados).</summary>
    public decimal OutstandingAmount { get; set; }

    /// <summary>Para pagos: Total - Σ líneas aplicadas (saldo por aplicar del pago).</summary>
    public decimal DifferenceAmount { get; set; }

    public string? Notes { get; set; }
    public bool IsVoided { get; set; }

    // Snapshot del proveedor
    public string? SupplierRegistration { get; set; }
    public string? SupplierAddress { get; set; }

    // Datos fiscales copiados del proveedor (compras)
    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public string? Correlative { get; set; }
    public DateTime? EmissionLimitDate { get; set; }

    public List<PayableDocumentLineDto> Lines { get; set; } = [];
    public List<PayableDocumentAttachmentDto> Attachments { get; set; } = [];
}
