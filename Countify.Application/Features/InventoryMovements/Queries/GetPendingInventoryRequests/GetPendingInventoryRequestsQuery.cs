using Countify.Application.Features.InventoryMovements.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryMovements.Queries.GetPendingInventoryRequests;

/// <summary>Solicitudes TP− vigentes y sin consumir (para el selector del ajuste negativo).</summary>
public class GetPendingInventoryRequestsQuery : IRequest<Response<List<InventoryMovementDto>>>;

public class GetPendingInventoryRequestsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetPendingInventoryRequestsQuery, Response<List<InventoryMovementDto>>>
{
    public async Task<Response<List<InventoryMovementDto>>> Handle(
        GetPendingInventoryRequestsQuery request, CancellationToken cancellationToken)
    {
        var consumedIds = await unitOfWork.InventoryMovements.Query()
            .Where(m => m.SourceRequestId != null && !m.IsVoided && m.Type!.Code == "AJ-")
            .Select(m => m.SourceRequestId!.Value)
            .Distinct()
            .ToListAsync(cancellationToken);
        var consumed = new HashSet<Guid>(consumedIds);

        var requests = await unitOfWork.InventoryMovements.Query()
            .Include(m => m.Type)
            .Include(m => m.Warehouse)
            .Where(m => !m.IsVoided && m.Type!.Code == "TP-")
            .OrderByDescending(m => m.Date)
            .ToListAsync(cancellationToken);

        requests = requests.Where(m => !consumed.Contains(m.Id))
            .OrderByDescending(m => m.Date).ToList();

        var dtos = requests.Select(m => new InventoryMovementDto
        {
            Id = m.Id,
            Code = m.Code,
            Correlativo = m.Correlativo,
            TypeId = m.TypeId,
            TypeCode = m.Type!.Code,
            TypeName = m.Type!.Name,
            Date = m.Date,
            Reference = m.Reference,
            Concept = m.Concept,
            WarehouseId = m.WarehouseId,
            WarehouseName = m.Warehouse?.Name ?? string.Empty,
            DepartmentId = m.DepartmentId,
            IsTaxExempt = m.IsTaxExempt,
            SubTotal = m.SubTotal,
            TaxAmount = m.TaxAmount,
            Total = m.Total,
            SourceRequestId = m.SourceRequestId,
            IsVoided = m.IsVoided,
            IsConsumed = false,
        }).ToList();

        return Response<List<InventoryMovementDto>>.Success(dtos);
    }
}
