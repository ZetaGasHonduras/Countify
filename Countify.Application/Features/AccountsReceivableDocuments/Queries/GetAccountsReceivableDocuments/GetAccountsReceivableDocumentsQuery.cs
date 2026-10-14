using AutoMapper;
using Countify.Application.Features.AccountsReceivableDocuments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocuments;

public class GetAccountsReceivableDocumentsQuery : IRequest<Response<List<AccountsReceivableDocumentDto>>>;

public class GetAccountsReceivableDocumentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAccountsReceivableDocumentsQuery, Response<List<AccountsReceivableDocumentDto>>>
{
    public async Task<Response<List<AccountsReceivableDocumentDto>>> Handle(
        GetAccountsReceivableDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await unitOfWork.AccountsReceivableDocuments.ToListAsync(
            unitOfWork.AccountsReceivableDocuments.Query()
                .Include(d => d.Customer)
                .Include(d => d.Concept)
                .Include(d => d.Department)
                .Include(d => d.Project)
                .Include(d => d.Currency)
                .OrderByDescending(d => d.DocumentNo),
            cancellationToken);

        var dtos = mapper.Map<List<AccountsReceivableDocumentDto>>(documents);

        if (documents.Count == 0)
            return Response<List<AccountsReceivableDocumentDto>>.Success(dtos);

        var ids = documents.Select(d => d.Id).ToList();

        var payments = (await unitOfWork.AccountsReceivableDocumentLines.ToListAsync(
                unitOfWork.AccountsReceivableDocumentLines.Query()
                    .Where(l => ids.Contains(l.AppliedDocumentId)),
                cancellationToken))
            .GroupBy(l => l.AppliedDocumentId)
            .ToDictionary(g => g.Key, g => g.Sum(l => l.Amount));

        var applied = (await unitOfWork.AccountsReceivableDocumentLines.ToListAsync(
                unitOfWork.AccountsReceivableDocumentLines.Query()
                    .Where(l => ids.Contains(l.DocumentId)),
                cancellationToken))
            .GroupBy(l => l.DocumentId)
            .ToDictionary(g => g.Key, g => g.Sum(l => l.Amount));

        foreach (var (dto, document) in dtos.Zip(documents))
        {
            if (!dto.IsVoided && !dto.IsCredit)
            {
                dto.OutstandingAmount = Math.Round(
                    dto.Amount - (payments.TryGetValue(document.Id, out var paid) ? paid : 0), 2);
            }

            dto.DifferenceAmount = Math.Round(
                dto.Amount - (applied.TryGetValue(document.Id, out var abonos) ? abonos : 0), 2);
        }

        return Response<List<AccountsReceivableDocumentDto>>.Success(dtos);
    }
}