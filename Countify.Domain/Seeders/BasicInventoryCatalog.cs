using Countify.Domain.Entities.Inventory;

namespace Countify.Domain.Seeders;

/// <summary>
/// Catálogo mínimo de inventario (legacy: BaseInventariosTipos AJ+/AJ−/TP−/COM,
/// Almacenes y Ubicaciones con "PredeterminarParaMovimientos" y la
/// UbicacionPredeterminada de Controles).
/// </summary>
public static class BasicInventoryCatalog
{
    public static readonly InventoryMovementType PositiveAdjustment = NewType(
        1, "AJ+", "Ajuste Positivo", InventoryMovementDirection.Entry, checksStock: false, generatesPosting: true);

    public static readonly InventoryMovementType NegativeAdjustment = NewType(
        2, "AJ-", "Ajuste Negativo", InventoryMovementDirection.Exit, checksStock: true, generatesPosting: true);

    public static readonly InventoryMovementType Request = NewType(
        3, "TP-", "Solicitud", InventoryMovementDirection.Exit, checksStock: false, generatesPosting: false);

    /// <summary>Reservado para el Ingreso de Compras (Etapa 5); oculto al alta manual.</summary>
    public static readonly InventoryMovementType PurchaseEntry = NewType(
        4, "COM", "Ingreso de Compras", InventoryMovementDirection.Entry, checksStock: false, generatesPosting: false);

    public static InventoryMovementType[] MovementTypes { get; } =
        [PositiveAdjustment, NegativeAdjustment, Request, PurchaseEntry];

    public static readonly Warehouse DefaultWarehouse = new()
    {
        Id = Guid.Parse("00000000-0000-4000-8000-696e76656e01"),
        Code = "ALM01",
        Name = "Almacén General",
        IsDefault = true,
    };

    public static readonly Location DefaultLocation = new()
    {
        Id = Guid.Parse("00000000-0000-4000-8000-696e76656e02"),
        Code = "PRED",
        Name = "Ubicación Predeterminada",
        WarehouseId = DefaultWarehouse.Id,
        ManageNegativeStock = true,
        IsDefault = true,
    };

    private static InventoryMovementType NewType(
        int id, string code, string name, InventoryMovementDirection direction,
        bool checksStock, bool generatesPosting)
        => new()
        {
            Id = Guid.Parse($"1a000000-0000-0000-0000-00000000000{id}"),
            Code = code,
            Name = name,
            Direction = direction,
            ChecksStock = checksStock,
            GeneratesPosting = generatesPosting,
            IsSystem = true,
        };
}
