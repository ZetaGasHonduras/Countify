using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.InventoryMovementTypes.Commands.DeleteInventoryMovementType;

public class DeleteInventoryMovementTypeCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteInventoryMovementTypeCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteInventoryMovementTypeCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteInventoryMovementTypeCommand request, CancellationToken cancellationToken)
    {
        var type = await unitOfWork.InventoryMovementTypes.GetByIdAsync(request.Id, cancellationToken);
        if (type is null)
            return Response<bool>.NotFound($"Tipo de movimiento {request.Id} no encontrado.");

        if (type.IsSystem)
            return Response<bool>.Failure(
                $"'{type.Code}' es un tipo del sistema (lo usan ajustes, solicitudes e ingresos de compra) y no se puede eliminar.");

        // Etapa 2: bloquear además si ya tiene movimientos que lo referencian.
        await unitOfWork.InventoryMovementTypes.DeleteAsync(type, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
