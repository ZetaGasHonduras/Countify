using AutoMapper;
using Countify.Application.Features.InventoryMovements.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryMovements.Queries.GetInventoryMovementById;

public class GetInventoryMovementByIdQuery : IRequest<Response<InventoryMovementDto>>
{
    public Guid Id { get; set; }
}

public class GetInventoryMovementByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetInventoryMovementByIdQuery, Response<InventoryMovementDto>>
{
    public async Task<Response<InventoryMovementDto>> Handle(
        GetInventoryMovementByIdQuery request, CancellationToken cancellationToken)
    {
        var movement = await unitOfWork.InventoryMovements.FirstOrDefaultAsync(
            unitOfWork.InventoryMovements.Query()
                .Include(m => m.Type)
                .Include(m => m.Warehouse)
                .Include(m => m.ToWarehouse)
                .Include(m => m.Department)
                .Include(m => m.SourceRequest)
                .Include(m => m.JournalEntry)
                .Include(m => m.Lines).ThenInclude(l => l.Product)
                .Include(m => m.Lines).ThenInclude(l => l.Location)
                .Where(m => m.Id == request.Id),
            cancellationToken);

        if (movement is null)
            return Response<InventoryMovementDto>.NotFound($"Movimiento de inventario {request.Id} no encontrado.");

        var dto = mapper.Map<InventoryMovementDto>(movement);
        dto.Lines = [.. dto.Lines.OrderBy(l => l.Order)];

        if (dto.TypeCode == "TP-")
            dto.IsConsumed = await unitOfWork.InventoryMovements.ExistsAsync(
                m => m.SourceRequestId == movement.Id && !m.IsVoided && m.Type!.Code == "AJ-",
                cancellationToken);

        return Response<InventoryMovementDto>.Success(dto);
    }
}
