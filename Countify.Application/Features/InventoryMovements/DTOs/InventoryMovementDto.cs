namespace Countify.Application.Features.InventoryMovements.DTOs;

public class InventoryMovementLineDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public Guid ProductId { get; set; }
    public string? ProductCode { get; set; }
    public string? ProductName { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public Guid LocationId { get; set; }
    public string? LocationCode { get; set; }
    public string? LocationName { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public decimal TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal LineTotal { get; set; }
}

public class InventoryMovementDto
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public int Correlativo { get; set; }

    public Guid TypeId { get; set; }
    public string TypeCode { get; set; } = string.Empty;
    public string TypeName { get; set; } = string.Empty;

    /// <summary>0 = sin inventario, 1 = entrada, 2 = salida.</summary>
    public int Direction { get; set; }

    public DateTime Date { get; set; }
    public string? Reference { get; set; }
    public string Concept { get; set; } = string.Empty;
    public string? Observations { get; set; }

    public Guid WarehouseId { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public Guid? ToWarehouseId { get; set; }
    public string? ToWarehouseName { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }

    public bool IsTaxExempt { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal Total { get; set; }

    public Guid? SourceRequestId { get; set; }
    public string? SourceRequestCode { get; set; }

    public Guid? JournalEntryId { get; set; }
    public int? JournalEntryNumber { get; set; }

    public bool IsVoided { get; set; }
    public DateTime? VoidedAt { get; set; }
    public string? VoidReason { get; set; }

    /// <summary>La solicitud ya fue consumida por un ajuste negativo.</summary>
    public bool IsConsumed { get; set; }

    public List<InventoryMovementLineDto> Lines { get; set; } = [];
}

public class InventoryStockDto
{
    public Guid ProductId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public Guid WarehouseId { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public Guid LocationId { get; set; }
    public string LocationCode { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    public decimal Inbound { get; set; }
    public decimal Outbound { get; set; }
    public decimal OnHand { get; set; }
}
