using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateProductCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateProductCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.Products.ExistsAsync(
            p => p.Code == request.Code, cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El producto '{request.Code}' ya existe.");

        var product = mapper.Map<Product>(request);
        await unitOfWork.Products.AddAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(product.Id, 201);
    }
}