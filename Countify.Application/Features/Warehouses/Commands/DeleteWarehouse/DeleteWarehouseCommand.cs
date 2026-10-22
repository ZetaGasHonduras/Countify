using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Warehouses.Commands.DeleteWarehouse;

public class DeleteWarehouseCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteWarehouseCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteWarehouseCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await unitOfWork.Warehouses.GetByIdAsync(request.Id, cancellationToken);
        if (warehouse is null)
            return Response<bool>.NotFound($"Almacén {request.Id} no encontrado.");

        var hasLocations = await unitOfWork.Locations.ExistsAsync(
            l => l.WarehouseId == warehouse.Id, cancellationToken);
        if (hasLocations)
            return Response<bool>.Failure("El almacén tiene ubicaciones; elimínelas primero.");

        if (warehouse.IsDefault)
            return Response<bool>.Failure("No se puede eliminar el almacén predeterminado.");

        await unitOfWork.Warehouses.DeleteAsync(warehouse, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
