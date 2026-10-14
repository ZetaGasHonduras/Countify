using Countify.Domain.Entities.AccountsReceivable;

namespace Countify.Domain.Seeders;

public static class BasicCustomers
{
    public static readonly Customer Lempira = NewCustomer(
        "CLI-001", "Distribuidora Lempira S. de R.L.",
        rtn: "08019000147632", email: "ventas@lempira.hn", phone: "2232-4455",
        address: "Col. Palmira, Tegucigalpa", creditDays: 30, creditLimit: 250000m);

    public static readonly Customer SanJorge = NewCustomer(
        "CLI-002", "Agroindustrias San Jorge S.A.",
        rtn: "05019098765000", email: "cobros@sanjorge.hn", phone: "2231-8890",
        address: "Boulevard Morazán, Tegucigalpa", creditDays: 45, creditLimit: 400000m);

    public static readonly Customer Palmero = NewCustomer(
        "CLI-003", "Inversiones Palmero, S.A.",
        rtn: "08019000001234", email: "info@palmero.hn", phone: "2235-1000",
        address: "Zona Vivero, San Pedro Sula");

    public static Customer[] Items { get; } = [Lempira, SanJorge, Palmero];

    public static Customer CashCustomer => Palmero;

    private static Customer NewCustomer(
        string code, string name,
        string? rtn = null, string? identity = null, string? email = null,
        string? phone = null, string? address = null,
        int creditDays = 0, decimal creditLimit = 0m)
        => new()
        {
            Id = Guid.NewGuid(),
            Code = code,
            Name = name,
            TaxId = rtn,
            IdentityDocument = identity,
            Email = email,
            Phone = phone,
            Address = address,
            CreditDays = creditDays,
            CreditLimit = creditLimit
        };
}