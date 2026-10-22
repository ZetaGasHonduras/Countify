namespace Countify.Application.Features.InventoryMovementTypes.DTOs;

public class InventoryMovementTypeDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    /// <summary>0 = Sin inventario, 1 = Entrada, 2 = Salida (enum legacy TipoDeMotivo).</summary>
    public int Direction { get; set; }

    public bool ChecksStock { get; set; }
    public bool GeneratesPosting { get; set; }
    public bool CountsForStock { get; set; } = true;
    public bool IsSystem { get; set; }
    public bool IsInactive { get; set; }
}
