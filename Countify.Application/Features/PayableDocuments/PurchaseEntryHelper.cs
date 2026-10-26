using Countify.Application.Features.PayableDocuments.Commands.CreatePayableDocument;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments;

/// <summary>
/// Validaciones y construcción compartidas del Ingreso de Compras (Etapa 5):
/// tipo COM, almacén, líneas con producto/ubicación y snapshot de descripción.
/// </summary>
internal static class PurchaseEntryHelper
{
    internal const string PurchaseEntryTypeCode = "COM";
    internal const int MaxLines = 999;

    internal static async Task<(InventoryMovementType? Type, string? Error)> GetPurchaseEntryTypeAsync(
        IUnitOfWork unitOfWork, CancellationToken cancellationToken)
    {
        var type = await unitOfWork.InventoryMovementTypes.Query()
            .FirstOrDefaultAsync(t => t.Code == PurchaseEntryTypeCode, cancellationToken);

        return type is null
            ? (null, "No existe el tipo de movimiento 'COM' (Ingreso de Compras) en Inventarios.")
            : (type, null);
    }

    internal static async Task<string?> ValidateWarehouseAsync(
        IUnitOfWork unitOfWork, Guid? warehouseId, CancellationToken cancellationToken)
    {
        if (warehouseId is not Guid id)
            return "El ingreso de compras requiere un almacén.";

        var warehouse = await unitOfWork.Warehouses.FirstOrDefaultAsync(
            unitOfWork.Warehouses.Query().Where(w => w.Id == id), cancellationToken);

        if (warehouse is null || warehouse.IsInactive)
            return "El almacén indicado no existe o está inactivo.";

        return null;
    }

    /// <summary>
    /// Valida las líneas y construye los detalles del movimiento (con snapshot de
    /// descripción desde el catálogo). Devuelve error o la lista construida.
    /// </summary>
    internal static async Task<(List<InventoryMovementLine> Lines, string? Error)> BuildLinesAsync(
        IUnitOfWork unitOfWork,
        Guid warehouseId,
        IReadOnlyCollection<CreatePayableDocumentCommand.PurchaseEntryLineInput> inputs,
        CancellationToken cancellationToken)
    {
        if (inputs.Count == 0)
            return ([], "El ingreso de compras debe tener al menos una línea de producto.");

        if (inputs.Count > MaxLines)
            return ([], $"El ingreso de compras no puede tener más de {MaxLines} líneas.");

        var productIds = inputs.Select(l => l.ProductId).Distinct().ToList();
        var products = await unitOfWork.Products.Query()
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync(cancellationToken);

        var locationIds = inputs.Select(l => l.LocationId).Distinct().ToList();
        var locations = await unitOfWork.Locations.Query()
            .Where(l => locationIds.Contains(l.Id))
            .ToListAsync(cancellationToken);

        var lines = new List<InventoryMovementLine>();
        var order = 1;

        foreach (var input in inputs)
        {
            var product = products.FirstOrDefault(p => p.Id == input.ProductId);
            if (product is null)
                return ([], "Un producto de las líneas no existe.");

            var location = locations.FirstOrDefault(l => l.Id == input.LocationId);
            if (location is null || location.IsInactive)
                return ([], "Una de las ubicaciones no existe o está inactiva.");

            if (location.WarehouseId != warehouseId)
                return ([], $"La ubicación {location.Code} no pertenece al almacén seleccionado.");

            lines.Add(new InventoryMovementLine
            {
                Order = order++,
                ProductId = input.ProductId,
                Description = string.IsNullOrWhiteSpace(input.Description)
                    ? product.Name
                    : input.Description.Trim(),
                Unit = string.IsNullOrWhiteSpace(input.Unit) ? null : input.Unit.Trim(),
                LocationId = input.LocationId,
                Quantity = input.Quantity,
                UnitCost = input.UnitCost,
                TaxRate = input.TaxRate,
            });
        }

        return (lines, null);
    }

    /// <summary>Correlativo 'COM' por tipo, estilo BaseInventarios legacy pero con max+1 (no COUNT).</summary>
    internal static async Task AssignNumberingAsync(
        IUnitOfWork unitOfWork, InventoryMovement movement, InventoryMovementType type,
        CancellationToken cancellationToken)
    {
        var max = await unitOfWork.InventoryMovements.Query()
            .Where(m => m.TypeId == type.Id)
            .Select(m => (int?)m.Correlativo).MaxAsync(cancellationToken);

        movement.Correlativo = (max ?? 0) + 1;
        movement.Code = $"{type.Code}{movement.Correlativo:D10}";
    }
}
