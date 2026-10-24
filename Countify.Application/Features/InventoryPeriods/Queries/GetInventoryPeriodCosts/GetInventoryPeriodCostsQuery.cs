using Countify.Application.Features.InventoryPeriods.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryPeriods.Queries.GetInventoryPeriodCosts;

public class GetInventoryPeriodCostsQuery : IRequest<Response<List<ProductCostHistoryDto>>>
{
    public Guid PeriodId { get; set; }
}

public class GetInventoryPeriodCostsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetInventoryPeriodCostsQuery, Response<List<ProductCostHistoryDto>>>
{
    public async Task<Response<List<ProductCostHistoryDto>>> Handle(
        GetInventoryPeriodCostsQuery request, CancellationToken cancellationToken)
    {
        if (!await unitOfWork.InventoryPeriods.ExistsAsync(p => p.Id == request.PeriodId, cancellationToken))
            return Response<List<ProductCostHistoryDto>>.NotFound("Período de inventario no encontrado.");

        var rows = await unitOfWork.ProductCostHistories.Query()
            .Where(c => c.InventoryPeriodId == request.PeriodId)
            .OrderBy(c => c.ProductCode)
            .ToListAsync(cancellationToken);

        return Response<List<ProductCostHistoryDto>>.Success(rows.Select(c => new ProductCostHistoryDto
        {
            Id = c.Id,
            ProductId = c.ProductId,
            ProductCode = c.ProductCode,
            ProductName = c.ProductName,
            Date = c.Date,
            Cost = c.Cost,
        }).ToList());
    }
}
