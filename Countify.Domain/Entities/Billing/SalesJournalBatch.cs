using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Entities.Billing;

/// <summary>
/// Partida de ventas mensual agregada. Corresponde a <c>CntPartidaDeVentas</c>
/// del sistema legacy: un rango de fechas que agrupa las facturas del período
/// en una única <see cref="JournalEntry"/> (<c>PRDCntCrearPartidaVentas</c>).
/// Las facturas quedan enlazadas vía <c>Invoice.SalesBatchId</c> para no duplicarse.
/// </summary>
public class SalesJournalBatch : BaseEntity
{
    public DateTime PeriodFrom { get; set; }
    public DateTime PeriodTo { get; set; }

    /// <summary>Partida generada (siempre existe al crear el lote).</summary>
    public Guid? JournalEntryId { get; set; }
    public JournalEntry? JournalEntry { get; set; }

    public string? Notes { get; set; }
}
