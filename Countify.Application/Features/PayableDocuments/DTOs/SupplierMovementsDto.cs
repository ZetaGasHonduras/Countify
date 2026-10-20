namespace Countify.Application.Features.PayableDocuments.DTOs;

/// <summary>
/// Estado de cuenta (movimientos) del proveedor con antigüedad de saldos al corte.
/// Equivalente a <c>VSTCXPEstadoDeCuenta</c> + aging (6 buckets, como CxC).
/// </summary>
public class SupplierMovementsDto
{
    public Guid SupplierId { get; set; }
    public string SupplierCode { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public decimal TotalCargos { get; set; }
    public decimal TotalAbonos { get; set; }
    public decimal Saldo { get; set; }
    public SupplierAgingDto Aging { get; set; } = new();
    public List<SupplierMovementDto> Movements { get; set; } = [];
}

public class SupplierMovementDto
{
    public Guid DocumentId { get; set; }
    public int DocumentNo { get; set; }

    /// <summary>El documento es un pago/abono (concepto Credit(2)).</summary>
    public bool IsPayment { get; set; }

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string? Reference { get; set; }
    public string ConceptDescription { get; set; } = string.Empty;
    public string CurrencyCode { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public decimal Tax { get; set; }

    /// <summary>Total = Amount + Tax.</summary>
    public decimal Total { get; set; }

    /// <summary>Total en moneda local (base del débito/crédito del estado de cuenta).</summary>
    public decimal TotalLocal { get; set; }

    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public decimal RunningBalance { get; set; }
    public decimal AppliedAmount { get; set; }
    public decimal OutstandingAmount { get; set; }

    /// <summary>Días vencidos a la fecha de corte (negativo = aún no vence).</summary>
    public int? DaysOverdue { get; set; }

    /// <summary>Bucket de antigüedad del saldo pendiente (null si no hay saldo pendiente).</summary>
    public string? AgingBucket { get; set; }

    public bool IsVoided { get; set; }
    public List<SupplierMovementApplicationDto> Applications { get; set; } = [];
}

/// <summary>
/// Antigüedad de saldos pendientes por pagar al corte (mejora sobre <c>VSTCXPEstadoDeCuenta</c>,
/// que no traía buckets; se usan los mismos 6 buckets de CxC).
/// </summary>
public class SupplierAgingDto
{
    /// <summary>Fecha de corte usada para calcular la antigüedad.</summary>
    public DateTime AsOfDate { get; set; }

    public decimal TotalOutstanding { get; set; }

    public List<SupplierAgingBucketDto> Buckets { get; set; } = [];

    public List<SupplierAgingDetailDto> Details { get; set; } = [];
}

public class SupplierAgingBucketDto
{
    /// <summary>Clave del bucket: current, d1_30, d31_60, d61_90, d91_120, d121_plus.</summary>
    public string Key { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}

public class SupplierAgingDetailDto
{
    public Guid DocumentId { get; set; }
    public int DocumentNo { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string? Reference { get; set; }
    public string ConceptDescription { get; set; } = string.Empty;
    public string CurrencyCode { get; set; } = string.Empty;
    public decimal AmountLocal { get; set; }
    public decimal AppliedAmount { get; set; }
    public decimal OutstandingAmount { get; set; }
    public int DaysOverdue { get; set; }
    public string BucketKey { get; set; } = string.Empty;
}

public class SupplierMovementApplicationDto
{
    public Guid Id { get; set; }
    public Guid RelatedDocumentId { get; set; }
    public int RelatedDocumentNo { get; set; }
    public DateTime RelatedDate { get; set; }
    public string? RelatedReference { get; set; }
    public string RelatedConcept { get; set; } = string.Empty;
    public bool RelatedIsPayment { get; set; }
    public decimal Amount { get; set; }
}
