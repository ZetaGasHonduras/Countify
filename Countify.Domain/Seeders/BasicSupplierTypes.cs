using Countify.Domain.Entities.AccountsPayable;

namespace Countify.Domain.Seeders;

/// <summary>
/// Tipos de proveedor iniciales (legacy: <c>Tiposproveedor</c>). La cuenta contable
/// (<c>CtaContable</c> en el legacy) se enlaza en el seeder por código de cuenta.
/// El tipo con <c>Code = "C"</c> replica el default del legacy
/// (<c>Proveedores.AfterConstruction</c> asignaba el tipo de código 'C').
/// </summary>
public static class BasicSupplierTypes
{
    public static readonly SupplierType Local = NewType(1, "L", "NACIONAL");
    public static readonly SupplierType Foreign = NewType(2, "E", "EXTRANJERO");
    public static readonly SupplierType CreditSupplier = NewType(3, "C", "PROVEEDOR CON CREDITO");

    public static SupplierType[] Items { get; } = [Local, Foreign, CreditSupplier];

    /// <summary>Tipo default (código 'C', como el legacy). Para ejemplo se enlaza a la cuenta de locales.</summary>
    public static readonly SupplierType Default = CreditSupplier;

    /// <summary>Cuenta contable que el seeder enlaza a cada tipo (código legacy <c>CtaContable</c>).</summary>
    public static readonly Dictionary<string, string> AccountCodesByTypeCode = new()
    {
        ["L"] = "2.1.1.1.001", // Locales (auxCxp)
        ["E"] = "2.1.1.1.002", // Extranjeros (auxCxp)
        ["C"] = "2.1.1.1.001", // Proveedor con crédito → cuenta de locales
    };

    private static SupplierType NewType(int id, string code, string name)
        => new()
        {
            Id = Guid.Parse($"0d000000-0000-0000-0000-000000000{id:D3}"),
            Code = code,
            Name = name,
        };
}
