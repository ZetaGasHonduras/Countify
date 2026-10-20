namespace Countify.Application.Features.SalesJournalBatches.DTOs;

public class SalesJournalBatchDto
{
    public Guid Id { get; set; }
    public DateTime PeriodFrom { get; set; }
    public DateTime PeriodTo { get; set; }
    public Guid? JournalEntryId { get; set; }
    public int? EntryNumber { get; set; }
    public string? Notes { get; set; }

    /// <summary>Cálculos sobre las facturas enlazadas al lote.</summary>
    public int InvoiceCount { get; set; }
    public decimal InvoicedTotal { get; set; }
}
