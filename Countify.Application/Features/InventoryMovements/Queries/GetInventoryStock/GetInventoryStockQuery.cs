using Countify.Application.Features.InventoryMovements.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryMovements.Queries.GetInventoryStock;

/// <summary>
/// Existencias derivadas (espejo de <c>VSTExistenciasUbicaciones</c>):
/// Σ entradas − Σ salidas por producto × ubicación. Solo pares con movimiento.
/// </summary>
public class GetInventoryStockQuery : IRequest<Response<List<InventoryStockDto>>>
{
    public Guid? WarehouseId { get; set; }
    public Guid? LocationId { get; set; }
    public Guid? ProductId { get; set; }
}

public class GetInventoryStockQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetInventoryStockQuery, Response<List<InventoryStockDto>>>
{
    public async Task<Response<List<InventoryStockDto>>> Handle(
        GetInventoryStockQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.InventoryMovementLines.Query()
            .Where(l => l.Movement != null && !l.Movement.IsVoided && l.Movement.Type!.CountsForStock);

        if (request.ProductId is Guid productId)
            query = query.Where(l => l.ProductId == productId);

        if (request.LocationId is Guid locationId)
            query = query.Where(l => l.LocationId == locationId);

        if (request.WarehouseId is Guid warehouseId)
            query = query.Where(l => l.Movement!.WarehouseId == warehouseId);

        var rows = await query
            .Select(l => new
            {
                l.ProductId,
                ProductCode = l.Product!.Code,
                ProductName = l.Product!.Name,
                WarehouseId = l.Movement!.WarehouseId,
                WarehouseName = l.Movement.Warehouse!.Name,
                l.LocationId,
                LocationCode = l.Location!.Code,
                LocationName = l.Location!.Name,
                Direction = l.Movement.Type!.Direction,
                l.Quantity,
            })
            .ToListAsync(cancellationToken);

        var dtos = rows
            .GroupBy(r => new { r.ProductId, r.LocationId })
            .Select(g => new InventoryStockDto
            {
                ProductId = g.Key.ProductId,
                LocationId = g.Key.LocationId,
                ProductCode = g.First().ProductCode,
                ProductName = g.First().ProductName,
                WarehouseId = g.First().WarehouseId,
                WarehouseName = g.First().WarehouseName,
                LocationCode = g.First().LocationCode,
                LocationName = g.First().LocationName,
                Inbound = g.Where(x => x.Direction == InventoryMovementDirection.Entry).Sum(x => x.Quantity),
                Outbound = g.Where(x => x.Direction == InventoryMovementDirection.Exit).Sum(x => x.Quantity),
            })
            .ToList();

        foreach (var dto in dtos)
            dto.OnHand = Math.Round(dto.Inbound - dto.Outbound, 3);

        return Response<List<InventoryStockDto>>.Success(
            dtos.OrderBy(d => d.WarehouseName).ThenBy(d => d.LocationCode).ThenBy(d => d.ProductCode).ToList());
    }
}
