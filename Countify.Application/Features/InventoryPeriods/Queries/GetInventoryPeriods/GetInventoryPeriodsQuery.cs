using Countify.Application.Features.InventoryPeriods.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryPeriods.Queries.GetInventoryPeriods;

public class GetInventoryPeriodsQuery : IRequest<Response<List<InventoryPeriodDto>>>;

public class GetInventoryPeriodsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetInventoryPeriodsQuery, Response<List<InventoryPeriodDto>>>
{
    public async Task<Response<List<InventoryPeriodDto>>> Handle(
        GetInventoryPeriodsQuery request, CancellationToken cancellationToken)
    {
        var periods = await unitOfWork.InventoryPeriods.Query()
            .OrderByDescending(p => p.Month)
            .ToListAsync(cancellationToken);

        var counts = await unitOfWork.ProductCostHistories.Query()
            .GroupBy(c => c.InventoryPeriodId)
            .Select(g => new { PeriodId = g.Key, Count = g.Count() })
            .ToListAsync(cancellationToken);

        var dtos = periods.Select(p => new InventoryPeriodDto
        {
            Id = p.Id,
            Month = p.Month,
            PeriodFrom = p.PeriodFrom,
            PeriodTo = p.PeriodTo,
            IsClosed = p.IsClosed,
            ClosedAt = p.ClosedAt,
            Notes = p.Notes,
            ProductCount = counts.FirstOrDefault(c => c.PeriodId == p.Id)?.Count ?? 0,
        }).ToList();

        return Response<List<InventoryPeriodDto>>.Success(dtos);
    }
}
