using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Suppliers.Commands.DeleteSupplier;

public class DeleteSupplierCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteSupplierCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteSupplierCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = await unitOfWork.Suppliers.GetByIdAsync(request.Id, cancellationToken);
        if (supplier is null)
            return Response<bool>.NotFound($"Proveedor {request.Id} no encontrado.");

        await unitOfWork.Suppliers.DeleteAsync(supplier, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
