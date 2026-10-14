using AutoMapper;
using Countify.Application.Features.AccountsReceivableDocuments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocumentById;

public class GetAccountsReceivableDocumentByIdQuery : IRequest<Response<AccountsReceivableDocumentDto>>
{
    public Guid Id { get; set; }
}

public class GetAccountsReceivableDocumentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAccountsReceivableDocumentByIdQuery, Response<AccountsReceivableDocumentDto>>
{
    public async Task<Response<AccountsReceivableDocumentDto>> Handle(
        GetAccountsReceivableDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        var document = await unitOfWork.AccountsReceivableDocuments.FirstOrDefaultAsync(
            unitOfWork.AccountsReceivableDocuments.Query()
                .Include(d => d.Customer)
                .Include(d => d.Concept)
                .Include(d => d.Department)
                .Include(d => d.Project)
                .Include(d => d.Currency)
                .Include(d => d.Lines)
                    .ThenInclude(l => l.AppliedDocument)
                        .ThenInclude(a => a.Concept)
                .Include(d => d.Lines)
                    .ThenInclude(l => l.AppliedDocument)
                        .ThenInclude(a => a.Currency)
                .Where(d => d.Id == request.Id),
            cancellationToken);

        if (document is null)
            return Response<AccountsReceivableDocumentDto>.NotFound($"Documento por cobrar {request.Id} no encontrado.");

        var dto = mapper.Map<AccountsReceivableDocumentDto>(document);

        decimal paid = 0, applied = 0;
        if (document.Lines.Count > 0)
        {
            var appliedIds = document.Lines.Select(l => l.AppliedDocumentId).ToList();
            var outstandingPerApplied = (await unitOfWork.AccountsReceivableDocumentLines.ToListAsync(
                    unitOfWork.AccountsReceivableDocumentLines.Query()
                        .Where(l => appliedIds.Contains(l.AppliedDocumentId)),
                    cancellationToken))
                .GroupBy(l => l.AppliedDocumentId)
                .ToDictionary(g => g.Key, g => g.Sum(l => l.Amount));

            foreach (var (lineDto, line) in dto.Lines.Zip(document.Lines))
            {
                if (outstandingPerApplied.TryGetValue(line.AppliedDocumentId, out var abonado))
                    lineDto.AppliedOutstandingAmount = Math.Round(lineDto.AppliedAmount - abonado, 2);
                applied += line.Amount;
            }
        }
        else
        {
            paid = (await unitOfWork.AccountsReceivableDocumentLines.ToListAsync(
                    unitOfWork.AccountsReceivableDocumentLines.Query()
                        .Where(l => l.AppliedDocumentId == request.Id),
                    cancellationToken))
                .Sum(l => l.Amount);
        }

        dto.DifferenceAmount = Math.Round(dto.Amount - applied, 2);
        if (!dto.IsVoided && !dto.IsCredit)
            dto.OutstandingAmount = Math.Round(dto.Amount - paid, 2);

        return Response<AccountsReceivableDocumentDto>.Success(dto);
    }
}