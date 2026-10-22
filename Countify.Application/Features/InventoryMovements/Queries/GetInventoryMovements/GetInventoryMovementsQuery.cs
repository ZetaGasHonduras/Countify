using AutoMapper;
using Countify.Application.Features.InventoryMovements.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryMovements.Queries.GetInventoryMovements;

public class GetInventoryMovementsQuery : IRequest<Response<List<InventoryMovementDto>>>;

public class GetInventoryMovementsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetInventoryMovementsQuery, Response<List<InventoryMovementDto>>>
{
    public async Task<Response<List<InventoryMovementDto>>> Handle(
        GetInventoryMovementsQuery request, CancellationToken cancellationToken)
    {
        var movements = await unitOfWork.InventoryMovements.ToListAsync(
            unitOfWork.InventoryMovements.Query()
                .Include(m => m.Type)
                .Include(m => m.Warehouse)
                .Include(m => m.SourceRequest)
                .OrderByDescending(m => m.Date).ThenByDescending(m => m.Code),
            cancellationToken);

        var dtos = mapper.Map<List<InventoryMovementDto>>(movements);

        var consumedIds = await unitOfWork.InventoryMovements.Query()
            .Where(m => m.SourceRequestId != null && !m.IsVoided)
            .Select(m => m.SourceRequestId!.Value)
            .Distinct()
            .ToListAsync(cancellationToken);
        var consumed = new HashSet<Guid>(consumedIds);

        foreach (var dto in dtos)
            dto.IsConsumed = dto.TypeCode == "TP-" && consumed.Contains(dto.Id);

        return Response<List<InventoryMovementDto>>.Success(dtos);
    }
}
