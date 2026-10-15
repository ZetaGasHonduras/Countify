namespace Countify.Application.Features.AccountsReceivableDocuments.DTOs;

public class CustomerMovementsDto
{
    public Guid CustomerId { get; set; }
    public string CustomerCode { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public decimal TotalCargos { get; set; }
    public decimal TotalAbonos { get; set; }
    public decimal Saldo { get; set; }
    public CustomerAgingDto Aging { get; set; } = new();
    public List<CustomerMovementDto> Movements { get; set; } = [];
}

public class CustomerMovementDto
{
    public Guid DocumentId { get; set; }
    public int DocumentNo { get; set; }
    public int? ReceiptNumber { get; set; }
    public bool IsCredit { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string? Reference { get; set; }
    public string ConceptDescription { get; set; } = string.Empty;
    public string CurrencyCode { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public decimal AmountLocal { get; set; }
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
    public List<CustomerMovementApplicationDto> Applications { get; set; } = [];
}

/// <summary>
/// Antigüedad de saldos pendientes por cobrar al corte (equivalente a <c>VSTCXCSaldos</c>).
/// </summary>
public class CustomerAgingDto
{
    /// <summary>Fecha de corte usada para calcular la antigüedad.</summary>
    public DateTime AsOfDate { get; set; }

    public decimal TotalOutstanding { get; set; }

    public List<CustomerAgingBucketDto> Buckets { get; set; } = [];

    public List<CustomerAgingDetailDto> Details { get; set; } = [];
}

public class CustomerAgingBucketDto
{
    /// <summary>Clave del bucket: current, d1_30, d31_60, d61_90, d91_120, d121_plus.</summary>
    public string Key { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}

public class CustomerAgingDetailDto
{
    public Guid DocumentId { get; set; }
    public int DocumentNo { get; set; }
    public int? ReceiptNumber { get; set; }
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

public class CustomerMovementApplicationDto
{
    public Guid Id { get; set; }
    public Guid RelatedDocumentId { get; set; }
    public int RelatedDocumentNo { get; set; }
    public int? RelatedReceiptNumber { get; set; }
    public DateTime RelatedDate { get; set; }
    public string? RelatedReference { get; set; }
    public string RelatedConcept { get; set; } = string.Empty;
    public bool RelatedIsCredit { get; set; }
    public decimal Amount { get; set; }
}
