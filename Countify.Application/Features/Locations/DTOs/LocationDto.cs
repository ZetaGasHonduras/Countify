namespace Countify.Application.Features.Locations.DTOs;

public class LocationDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid WarehouseId { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public Guid? AccountId { get; set; }
    public string? AccountCode { get; set; }
    public string? AccountName { get; set; }
    public Guid? ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public bool ManageNegativeStock { get; set; }
    public bool IsDefault { get; set; }
    public bool IsInactive { get; set; }
    public string? Observations { get; set; }
}
