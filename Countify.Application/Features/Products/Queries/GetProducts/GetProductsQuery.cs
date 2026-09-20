using AutoMapper;
using Countify.Application.Features.Products.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Products.Queries.GetProducts;

public class GetProductsQuery : IRequest<Response<List<ProductDto>>>;

public class GetProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetProductsQuery, Response<List<ProductDto>>>
{
    public async Task<Response<List<ProductDto>>> Handle(
        GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await unitOfWork.Products.ToListAsync(
            unitOfWork.Products.Query().OrderBy(p => p.Code),
            cancellationToken);

        return Response<List<ProductDto>>.Success(
            mapper.Map<List<ProductDto>>(products));
    }
}