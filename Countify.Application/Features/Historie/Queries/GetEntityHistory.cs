using AutoMapper;
using Countify.Application.Extensions;
using Countify.Application.Features.Historie.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Common;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Historie.Queries;

public class GetEntityHistoryQuery : RequestParameter, IRequest<Response<List<HistoryDto>>>
{
    public string Entity { get; set; } = string.Empty;
    public Guid EntityId { get; set; }
}

public class GetEntityHistoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<GetEntityHistoryQuery, Response<List<HistoryDto>>>
{
    public async Task<Response<List<HistoryDto>>> Handle(
        GetEntityHistoryQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.Histories.Query()
            .ApplySearch(request.Parameter, x => x.Property.Contains(request.Parameter!))
            .ApplyOrder(request.Column, request.Order == OrderColumns.Ascending, x => x.Date, new()
            {
                ["Date"] = x => x.Date,
                ["Property"] = x => x.Property
            });

        var history = await unitOfWork.Histories.ToListAsync(
            query
                .Where(x => x.Entity == request.Entity && x.EntityId == request.EntityId),
            cancellationToken);

        return Response<List<HistoryDto>>.Success(mapper.Map<List<HistoryDto>>(history));
    }
}