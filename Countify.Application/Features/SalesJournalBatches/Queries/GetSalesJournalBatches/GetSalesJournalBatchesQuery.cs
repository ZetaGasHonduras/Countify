using AutoMapper;
using Countify.Application.Features.SalesJournalBatches.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.SalesJournalBatches.Queries.GetSalesJournalBatches;

public class GetSalesJournalBatchesQuery : IRequest<Response<List<SalesJournalBatchDto>>>;

public class GetSalesJournalBatchesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetSalesJournalBatchesQuery, Response<List<SalesJournalBatchDto>>>
{
    public async Task<Response<List<SalesJournalBatchDto>>> Handle(
        GetSalesJournalBatchesQuery request, CancellationToken cancellationToken)
    {
        var batches = await unitOfWork.SalesJournalBatches.ToListAsync(
            unitOfWork.SalesJournalBatches.Query()
                .Include(b => b.JournalEntry)
                .OrderByDescending(b => b.PeriodTo),
            cancellationToken);

        var stats = await unitOfWork.Invoices.Query()
            .Where(i => i.SalesBatchId != null)
            .GroupBy(i => i.SalesBatchId!.Value)
            .Select(g => new { BatchId = g.Key, Count = g.Count(), Total = g.Sum(i => i.TotalLocal) })
            .ToListAsync(cancellationToken);

        var dtos = mapper.Map<List<SalesJournalBatchDto>>(batches);
        foreach (var dto in dtos)
        {
            var stat = stats.FirstOrDefault(s => s.BatchId == dto.Id);
            dto.InvoiceCount = stat?.Count ?? 0;
            dto.InvoicedTotal = stat?.Total ?? 0;
        }

        return Response<List<SalesJournalBatchDto>>.Success(dtos);
    }
}
