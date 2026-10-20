using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Entities.AccountsPayable;

/// <summary>
/// Tipo de concepto de CxP. Conserva los valores numéricos del legacy
/// (<c>TipoConcepto { Debito = 1, Credito = 2 }</c>) y también su <em>inversión de
/// nombres</em>: en el sistema viejo el valor 1 se mostraba como "Crédito a Proveedor".
/// Semántica canónica (espejo de <c>AccountsReceivableConceptType</c> en CxC):
/// <list type="bullet">
/// <item><description><see cref="Debit"/> (1) = factura/compra: aumenta el saldo por pagar;
/// es la que recibe pagos y copia los datos fiscales del proveedor.</description></item>
/// <item><description><see cref="Credit"/> (2) = pago/abono: reduce el saldo; aplica contra
/// facturas vía líneas.</description></item>
/// </list>
/// </summary>
public enum PayableConceptType
{
    Debit = 1,
    Credit = 2
}

/// <summary>
/// Concepto de CxP. Corresponde a <c>CXPConceptos</c> del sistema legacy.
/// </summary>
public class PayableConcept : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public PayableConceptType Type { get; set; } = PayableConceptType.Debit;
    public Guid? AccountId { get; set; }
    public Account? Account { get; set; }
    public bool IsInactive { get; set; }
    public bool GeneratePosting { get; set; }

    /// <summary>El concepto representa un pago/abono (Tipo = Credit) que aplica contra facturas.</summary>
    public bool IsPayment { get; set; }

    public string? Observations { get; set; }
}
