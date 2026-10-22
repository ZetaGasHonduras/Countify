namespace Countify.Application.Features.Warehouses.DTOs;

public class WarehouseDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public bool IsInactive { get; set; }
    public int LocationCount { get; set; }
}
