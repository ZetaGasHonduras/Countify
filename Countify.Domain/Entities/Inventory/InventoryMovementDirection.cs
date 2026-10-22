namespace Countify.Domain.Entities.Inventory;

/// <summary>
/// Dirección del tipo de movimiento. Espejo del enum legacy
/// <c>PublicEnums.TipoDeMotivo { SININVENTARIO=0, ENTRADA=1, SALIDA=2 }</c>.
/// </summary>
public enum InventoryMovementDirection
{
    NoStock = 0,
    Entry = 1,
    Exit = 2
}
