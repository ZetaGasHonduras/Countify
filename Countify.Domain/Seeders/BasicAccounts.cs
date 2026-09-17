using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicAccounts
{
    public static readonly Account Assets = NewAccount("50000000-0000-0000-0000-000000000001", "1", "Activo", level: 1);
    public static readonly Account CurrentAssets = NewAccount("50000000-0000-0000-0000-000000000002", "11", "Activo Corriente", "1", 2);
    public static readonly Account Cash = NewAccount("50000000-0000-0000-0000-000000000003", "111", "Caja", "11", 3, operable: true);
    public static readonly Account Banks = NewAccount("50000000-0000-0000-0000-000000000004", "112", "Bancos", "11", 3, operable: true, bank: true);
    public static readonly Account NonCurrentAssets = NewAccount("50000000-0000-0000-0000-000000000005", "12", "Activo No Corriente", "1", 2);
    public static readonly Account FurnitureAndEquipment = NewAccount("50000000-0000-0000-0000-000000000006", "121", "Mobiliario y Equipo", "12", 3, operable: true);

    public static readonly Account Liabilities = NewAccount("50000000-0000-0000-0000-000000000007", "2", "Pasivo", level: 1);
    public static readonly Account CurrentLiabilities = NewAccount("50000000-0000-0000-0000-000000000008", "21", "Pasivo Corriente", "2", 2);
    public static readonly Account Suppliers = NewAccount("50000000-0000-0000-0000-000000000009", "211", "Proveedores", "21", 3, operable: true, auxCxp: true);
    public static readonly Account NonCurrentLiabilities = NewAccount("50000000-0000-0000-0000-000000000010", "22", "Pasivo No Corriente", "2", 2);
    public static readonly Account BankLoans = NewAccount("50000000-0000-0000-0000-000000000011", "221", "Préstamos Bancarios", "22", 3, operable: true);

    public static readonly Account Equity = NewAccount("50000000-0000-0000-0000-000000000012", "3", "Patrimonio", level: 1);
    public static readonly Account CapitalStock = NewAccount("50000000-0000-0000-0000-000000000013", "31", "Capital Social", "3", 2, operable: true);

    public static readonly Account Revenues = NewAccount("50000000-0000-0000-0000-000000000014", "4", "Ingresos", level: 1);
    public static readonly Account ServiceRevenue = NewAccount("50000000-0000-0000-0000-000000000015", "41", "Ingresos por Servicios", "4", 2, operable: true);

    public static readonly Account Costs = NewAccount("50000000-0000-0000-0000-000000000016", "5", "Costos", level: 1);
    public static readonly Account CostOfSales = NewAccount("50000000-0000-0000-0000-000000000017", "51", "Costo de Ventas", "5", 2, operable: true);

    public static readonly Account Expenses = NewAccount("50000000-0000-0000-0000-000000000018", "6", "Gastos", level: 1);
    public static readonly Account OperatingExpenses = NewAccount("50000000-0000-0000-0000-000000000019", "61", "Gastos de Operación", "6", 2, operable: true);

    public static Account[] Items { get; } =
    [
        Assets, CurrentAssets, Cash, Banks, NonCurrentAssets, FurnitureAndEquipment,
        Liabilities, CurrentLiabilities, Suppliers, NonCurrentLiabilities, BankLoans,
        Equity, CapitalStock,
        Revenues, ServiceRevenue,
        Costs, CostOfSales,
        Expenses, OperatingExpenses
    ];

    private static Account NewAccount(
        string id, string code, string name, string? parentCode = null, int level = 1,
        bool operable = false, bool bank = false, bool auxCxp = false)
        => new()
        {
            Id = Guid.Parse(id),
            Code = code,
            Name = name,
            ParentCode = parentCode,
            Level = level,
            IsOperable = operable,
            IsBankAccount = bank,
            IsAuxCxp = auxCxp
        };
}