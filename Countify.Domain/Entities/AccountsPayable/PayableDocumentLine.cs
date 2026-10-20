using Countify.Domain.Common;

namespace Countify.Domain.Entities.AccountsPayable;

/// <summary>
/// Línea de aplicación pago → factura. Corresponde a <c>CXPDocumentosHijo</c> del sistema
/// legacy (espejo de <c>AccountsReceivableDocumentLine</c>).
/// </summary>
public class PayableDocumentLine : BaseEntity
{
    /// <summary>El pago (documento Credit) que aplica.</summary>
    public Guid DocumentId { get; set; }
    public PayableDocument Document { get; set; } = null!;

    /// <summary>La factura/compra (documento Debit) aplicada.</summary>
    public Guid AppliedDocumentId { get; set; }
    public PayableDocument AppliedDocument { get; set; } = null!;

    public decimal Amount { get; set; }
}
