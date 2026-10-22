using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryMovements.Commands.DeleteInventoryMovement;

/// <summary>
/// Solo las solicitudes TP− sin consumir pueden eliminarse (paridad legacy: los
/// documentos con partida no se borran, se anulan).
/// </summary>
public class DeleteInventoryMovementCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteInventoryMovementCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteInventoryMovementCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteInventoryMovementCommand request, CancellationToken cancellationToken)
    {
        var movement = await unitOfWork.InventoryMovements.Query()
            .Include(m => m.Type)
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (movement is null)
            return Response<bool>.NotFound($"Movimiento de inventario {request.Id} no encontrado.");

        if (movement.Type?.Code != "TP-")
            return Response<bool>.Failure("Solo las solicitudes sin consumir pueden eliminarse; use anular.");

        if (!movement.IsVoided &&
            await unitOfWork.InventoryMovements.ExistsAsync(
                m => m.SourceRequestId == movement.Id && !m.IsVoided && m.Type!.Code == "AJ-",
                cancellationToken))
            return Response<bool>.Failure("La solicitud ya fue consumida por un ajuste negativo.");

        await unitOfWork.InventoryMovements.DeleteAsync(movement, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
