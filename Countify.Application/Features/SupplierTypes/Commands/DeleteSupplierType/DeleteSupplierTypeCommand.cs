using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.SupplierTypes.Commands.DeleteSupplierType;

public class DeleteSupplierTypeCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteSupplierTypeCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteSupplierTypeCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteSupplierTypeCommand request, CancellationToken cancellationToken)
    {
        var supplierType = await unitOfWork.SupplierTypes.GetByIdAsync(request.Id, cancellationToken);
        if (supplierType is null)
            return Response<bool>.NotFound($"Tipo de proveedor {request.Id} no encontrado.");

        var hasAssignments = await unitOfWork.Suppliers.ExistsAsync(
            s => s.SupplierTypeId == request.Id, cancellationToken);

        if (hasAssignments)
            return Response<bool>.Failure("No se puede eliminar: el tipo de proveedor está asignado a proveedores.");

        await unitOfWork.SupplierTypes.DeleteAsync(supplierType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
