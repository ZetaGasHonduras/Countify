using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Entities.AccountsPayable;

/// <summary>
/// Tipo de proveedor. Corresponde a <c>Tiposproveedor</c> del sistema legacy.
/// </summary>
public class SupplierType : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? AccountingAccountId { get; set; }
    public Account? AccountingAccount { get; set; }
}
