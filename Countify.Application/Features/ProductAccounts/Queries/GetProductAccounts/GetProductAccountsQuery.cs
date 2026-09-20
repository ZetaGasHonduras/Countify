using AutoMapper;
using Countify.Application.Extensions;
using Countify.Application.Features.ProductAccounts.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.ProductAccounts.Queries.GetProductAccounts;

public class GetProductAccountsQuery : RequestParameter, IRequest<PaginatedResponse<List<ProductAccountDto>>>
{
    public string? Search { get; set; }
}

public class GetProductAccountsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetProductAccountsQuery, PaginatedResponse<List<ProductAccountDto>>>
{
    public async Task<PaginatedResponse<List<ProductAccountDto>>> Handle(
        GetProductAccountsQuery request, CancellationToken cancellationToken)
    {
        if (request.PageSize <= 0) request.PageSize = 10;
        if (request.PageNumber < 0) request.PageNumber = 0;

        var search = request.Search ?? request.Parameter;

        var query = unitOfWork.ProductAccounts.Query()
            .Include(p => p.Product)
            .Include(p => p.Quality)
            .Include(p => p.InventoryAccount)
            .Include(p => p.IncomeAccount)
            .Include(p => p.CostAccount)
            .ApplySearch(search, p =>
                (p.Product != null && p.Product.Code.Contains(search!))
                || (p.Product != null && p.Product.Name.Contains(search!))
                || (p.Quality != null && p.Quality.Name.Contains(search!)));

        var totalCount = await unitOfWork.ProductAccounts.CountAsync(query, cancellationToken);

        if (request.All)
        {
            request.PageNumber = 0;
            request.PageSize = totalCount == 0 ? 1 : totalCount;
        }

        var items = await unitOfWork.ProductAccounts.ToListAsync(
            query
                .OrderBy(p => p.Product != null ? p.Product.Name : string.Empty)
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize),
            cancellationToken);

        var dtos = mapper.Map<List<ProductAccountDto>>(items);

        return new PaginatedResponse<List<ProductAccountDto>>(
            dtos, request.PageNumber, request.PageSize, totalCount);
    }
}