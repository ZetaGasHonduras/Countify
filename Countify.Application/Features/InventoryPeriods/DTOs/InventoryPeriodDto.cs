namespace Countify.Application.Features.InventoryPeriods.DTOs;

public class InventoryPeriodDto
{
    public Guid Id { get; set; }

    /// <summary>Primer día del mes (yyyy-MM-dd). El front lo pinta como "MMM yyyy".</summary>
    public DateTime Month { get; set; }

    public DateTime PeriodFrom { get; set; }
    public DateTime PeriodTo { get; set; }
    public bool IsClosed { get; set; }
    public DateTime? ClosedAt { get; set; }
    public string? Notes { get; set; }
    public int ProductCount { get; set; }
}

public class ProductCostHistoryDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal Cost { get; set; }
}
