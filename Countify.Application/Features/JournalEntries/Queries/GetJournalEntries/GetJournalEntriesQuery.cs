using AutoMapper;
using Countify.Application.Extensions;
using Countify.Application.Features.JournalEntries.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.JournalEntries.Queries.GetJournalEntries;

public class GetJournalEntriesQuery : RequestParameter, IRequest<PaginatedResponse<List<JournalEntryDto>>>
{
    public string? Search { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public JournalEntryStatus? Status { get; set; }
}

public class GetJournalEntriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetJournalEntriesQuery, PaginatedResponse<List<JournalEntryDto>>>
{
    public async Task<PaginatedResponse<List<JournalEntryDto>>> Handle(
        GetJournalEntriesQuery request, CancellationToken cancellationToken)
    {
        if (request.PageSize <= 0) request.PageSize = 10;
        if (request.PageNumber < 0) request.PageNumber = 0;

        var search = request.Search ?? request.Parameter;

        var query = unitOfWork.JournalEntries.Query()
            .Include(e => e.Type)
            .WhereIf(request.FromDate.HasValue, e => e.ReferenceDate >= request.FromDate!.Value)
            .WhereIf(request.ToDate.HasValue, e => e.ReferenceDate <= request.ToDate!.Value)
            .WhereIf(request.Status.HasValue, e => e.Status == request.Status!.Value)
            .ApplySearch(search, e =>
                e.Reference.Contains(search!)
                || e.Concept.Contains(search!)
                || (e.Code != null && e.Code.Contains(search!)));

        var totalCount = await unitOfWork.JournalEntries.CountAsync(query, cancellationToken);

        if (request.All)
        {
            request.PageNumber = 0;
            request.PageSize = totalCount == 0 ? 1 : totalCount;
        }

        var entries = await unitOfWork.JournalEntries.ToListAsync(
            query
                .OrderByDescending(e => e.ReferenceDate)
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize),
            cancellationToken);

        var dtos = mapper.Map<List<JournalEntryDto>>(entries);
        foreach (var dto in dtos)
            dto.Lines ??= [];

        return new PaginatedResponse<List<JournalEntryDto>>(
            dtos, request.PageNumber, request.PageSize, totalCount);
    }
}