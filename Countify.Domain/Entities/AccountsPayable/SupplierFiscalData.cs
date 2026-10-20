using Countify.Domain.Common;

namespace Countify.Domain.Entities.AccountsPayable;

/// <summary>
/// Datos fiscales del proveedor (CAI, rangos y correlativo). Puede haber varios por
/// proveedor, de los cuales se usa el activo al registrar una compra.
/// Corresponde a <c>ProveedoresDatosFiscales</c> del sistema legacy.
/// </summary>
public class SupplierFiscalData : BaseEntity
{
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;

    public string? Branch { get; set; }
    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public string? Correlative { get; set; }
    public DateTime? EmissionLimitDate { get; set; }
    public bool IsActive { get; set; } = true;
}
