using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            return Response<bool>.NotFound($"Producto {request.Id} no encontrado.");

        var hasAssignments = await unitOfWork.ProductAccounts.ExistsAsync(
            a => a.ProductId == request.Id, cancellationToken);

        if (hasAssignments)
            return Response<bool>.Failure("No se puede eliminar: el producto está asignado en cuentas por producto.");

        await unitOfWork.Products.DeleteAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}