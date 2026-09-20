using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateProductCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            return Response<bool>.NotFound($"Producto {request.Id} no encontrado.");

        var codeInUse = await unitOfWork.Products.ExistsAsync(
            p => p.Code == request.Code && p.Id != request.Id, cancellationToken);

        if (codeInUse)
            return Response<bool>.Failure($"El producto '{request.Code}' ya existe.");

        mapper.Map(request, product);
        await unitOfWork.Products.UpdateAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}