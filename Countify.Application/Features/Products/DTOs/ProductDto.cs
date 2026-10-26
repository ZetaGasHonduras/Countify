namespace Countify.Application.Features.Products.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    /// <summary>Precio de venta por defecto (legacy Preciounit).</summary>
    public decimal SalePrice { get; set; }

    /// <summary>Último costo promedio ponderado (solo lectura: lo fija el cierre de período).</summary>
    public decimal LastCost { get; set; }
}