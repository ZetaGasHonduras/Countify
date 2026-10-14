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
    public bool IsVoided { get; set; }
    public List<CustomerMovementApplicationDto> Applications { get; set; } = [];
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