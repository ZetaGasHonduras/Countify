using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class Product : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Precio de venta por defecto al facturar (legacy: <c>Productos.Preciounit</c>,
    /// que el legacy autocompletaba en la línea). 0 = sin precio capturado.
    /// </summary>
    public decimal SalePrice { get; set; }

    /// <summary>
    /// Último costo promedio ponderado (legacy: <c>Productos.Costo/Costopro</c>).
    /// Se recarga al cerrar el período de inventario; prellena el costo de ajustes e ingresos.
    /// </summary>
    public decimal LastCost { get; set; }
}