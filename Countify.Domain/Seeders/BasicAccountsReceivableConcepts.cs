using Countify.Domain.Entities.AccountsReceivable;

namespace Countify.Domain.Seeders;

public static class BasicAccountsReceivableConcepts
{
    public static readonly AccountsReceivableConcept Invoice = NewConcept(
        1, "FACTURA", AccountsReceivableConceptType.Debit, generatePosting: true);

    public static readonly AccountsReceivableConcept InvoiceCancellation = NewConcept(
        2, "ANULACION DE FACTURA", AccountsReceivableConceptType.Credit, generatePosting: true);

    public static readonly AccountsReceivableConcept Receipt = NewConcept(
        3, "RECIBO", AccountsReceivableConceptType.Credit, generatePosting: true, isReceipt: true);

    public static readonly AccountsReceivableConcept DownPayment = NewConcept(
        4, "ABONO", AccountsReceivableConceptType.Debit, generatePosting: false);

    public static AccountsReceivableConcept[] Items { get; } = [Invoice, InvoiceCancellation, Receipt, DownPayment];

    private static AccountsReceivableConcept NewConcept(
        int id, string description, AccountsReceivableConceptType type, bool generatePosting, bool isReceipt = false)
        => new()
        {
            Id = Guid.Parse($"0b000000-0000-0000-0000-000000000{id:D3}"),
            Description = description,
            Type = type,
            GeneratePosting = generatePosting,
            IsReceipt = isReceipt
        };
}