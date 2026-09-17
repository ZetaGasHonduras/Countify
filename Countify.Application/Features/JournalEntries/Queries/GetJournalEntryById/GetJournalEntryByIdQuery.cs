using AutoMapper;
using Countify.Application.Features.JournalEntries.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.JournalEntries.Queries.GetJournalEntryById;

public class GetJournalEntryByIdQuery : IRequest<Response<JournalEntryDto>>
{
    public Guid Id { get; set; }
}

public class GetJournalEntryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetJournalEntryByIdQuery, Response<JournalEntryDto>>
{
    public async Task<Response<JournalEntryDto>> Handle(
        GetJournalEntryByIdQuery request, CancellationToken cancellationToken)
    {
        var entry = await unitOfWork.JournalEntries.Query()
            .Include(e => e.Type)
            .Include(e => e.Lines)
            .ThenInclude(l => l.Account)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (entry is null)
            return Response<JournalEntryDto>.NotFound($"Partida {request.Id} no encontrada.");

        var dto = mapper.Map<JournalEntryDto>(entry);
        dto.Lines ??= [];

        return Response<JournalEntryDto>.Success(dto);
    }
}