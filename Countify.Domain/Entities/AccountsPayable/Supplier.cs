using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Entities.AccountsPayable;

/// <summary>
/// Proveedor. Corresponde a <c>Proveedores</c> del sistema legacy.
/// Espejo de <c>Customer</c> en Cuentas por Cobrar.
/// </summary>
public class Supplier : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? SupplierTypeId { get; set; }
    public SupplierType? SupplierType { get; set; }
    public string? TaxId { get; set; }
    public string? IdentityDocument { get; set; }
    public string? Registration { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPosition { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public int CreditDays { get; set; }
    public decimal CreditLimit { get; set; }
    public Guid? AccountingAccountId { get; set; }
    public Account? AccountingAccount { get; set; }
    public bool IsInactive { get; set; }

    public ICollection<SupplierFiscalData> FiscalData { get; set; } = [];
}
