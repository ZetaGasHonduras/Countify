using Countify.Domain.Entities.AccountsPayable;

namespace Countify.Domain.Seeders;

/// <summary>
/// Proveedores de ejemplo iniciales (legacy: <c>Proveedores</c>). Espejo de
/// <c>BasicCustomers</c>: los enlaces a <see cref="SupplierType"/> y a la cuenta
/// contable se resuelven en el seeder (ver <see cref="Links"/>), no aquí.
/// </summary>
public static class BasicSuppliers
{
    public static readonly Supplier ProviderGeneral = NewSupplier(
        1, "P001", "PROVEEDOR GENERAL",
        rtn: "08011990000110", email: "ventas@proveedorgeneral.hn", phone: "2222-4455",
        address: "Col. Palmira, Tegucigalpa", creditDays: 30, creditLimit: 100000m);

    public static readonly Supplier ProviderServices = NewSupplier(
        2, "P002", "SERVICIOS Y MANTENIMIENTO, S.A.",
        rtn: "08011995000220", email: "cobros@serviciosmn.hn", phone: "2231-8890",
        address: "Blvd. Morazán, Tegucigalpa", creditDays: 15, creditLimit: 50000m);

    public static readonly Supplier ProviderForeign = NewSupplier(
        3, "P003", "TRADING IMPORT EXPORT",
        email: "orders@tradingimport.com", phone: "504-2555-1000",
        address: "Puerto Cortés, Cortés", creditDays: 60, creditLimit: 200000m);

    public static Supplier[] Items { get; } = [ProviderGeneral, ProviderServices, ProviderForeign];

    /// <summary>Código de tipo de proveedor (legacy <c>Tipoproveedor</c>) que el seeder enlaza por proveedor.</summary>
    public static readonly Dictionary<Supplier, string> TypeCodes = new()
    {
        [ProviderGeneral] = "C",
        [ProviderServices] = "C",
        [ProviderForeign] = "E",
    };

    /// <summary>Código de cuenta contable (legacy <c>Ctacontable</c>) que el seeder enlaza por proveedor.</summary>
    public static readonly Dictionary<Supplier, string> AccountCodes = new()
    {
        [ProviderGeneral] = "2.1.1.1.001",
        [ProviderServices] = "2.1.1.1.001",
        [ProviderForeign] = "2.1.1.1.002",
    };

    /// <summary>
    /// Dato fiscal (CAI) de ejemplo, activo, enlazado a <see cref="ProviderGeneral"/>
    /// (legacy <c>ProveedoresDatosFiscales</c>) para que las compras copien datos fiscales.
    /// </summary>
    public static readonly SupplierFiscalData ProviderGeneralFiscal = new()
    {
        Supplier = ProviderGeneral,
        Branch = "01",
        CAI = "00000000000000000000000000000000000000000000",
        RangeFrom = "1",
        RangeTo = "1000",
        Correlative = "1",
        EmissionLimitDate = new DateTime(2099, 12, 31),
        IsActive = true,
    };

    private static Supplier NewSupplier(
        int id, string code, string name,
        string? rtn = null, string? identity = null, string? email = null,
        string? phone = null, string? address = null,
        int creditDays = 0, decimal creditLimit = 0m)
        => new()
        {
            Id = Guid.Parse($"0e000000-0000-0000-0000-000000000{id:D3}"),
            Code = code,
            Name = name,
            TaxId = rtn,
            IdentityDocument = identity,
            Email = email,
            Phone = phone,
            Address = address,
            City = "Tegucigalpa",
            Registration = $"REG-{code}",
            CreditDays = creditDays,
            CreditLimit = creditLimit,
        };
}
