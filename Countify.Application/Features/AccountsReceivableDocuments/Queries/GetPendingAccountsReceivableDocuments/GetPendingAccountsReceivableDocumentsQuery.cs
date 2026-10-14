using AutoMapper;
using Countify.Application.Features.AccountsReceivableDocuments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.AccountsReceivableDocuments.Queries.GetPendingAccountsReceivableDocuments;

public class GetPendingAccountsReceivableDocumentsQuery
    : IRequest<Response<List<AccountsReceivableDocumentDto>>>
{
    public Guid CustomerId { get; set; }
    public List<Guid> ExcludeDocumentIds { get; set; } = [];
}

public class GetPendingAccountsReceivableDocumentsQueryHandler(
    IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetPendingAccountsReceivableDocumentsQuery, Response<List<AccountsReceivableDocumentDto>>>
{
    public async Task<Response<List<AccountsReceivableDocumentDto>>> Handle(
        GetPendingAccountsReceivableDocumentsQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.AccountsReceivableDocuments.Query()
            .Include(d => d.Customer)
            .Include(d => d.Concept)
            .Include(d => d.Currency)
            .Where(d => d.CustomerId == request.CustomerId
                && !d.IsVoided
                && d.Concept != null
                && d.Concept.Type == AccountsReceivableConceptType.Debit
                && d.Amount > 0);

        if (request.ExcludeDocumentIds.Count > 0)
        {
            query = query.Where(d => !request.ExcludeDocumentIds.Contains(d.Id));
        }

        var documents = await unitOfWork.AccountsReceivableDocuments.ToListAsync(
            query.OrderBy(d => d.DocumentNo), cancellationToken);

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

        foreach (var (dto, document) in dtos.Zip(documents))
        {
            dto.OutstandingAmount = Math.Round(
                dto.Amount - (payments.TryGetValue(document.Id, out var paid) ? paid : 0), 2);
        }

        dtos = dtos.Where(d => d.OutstandingAmount > 0).ToList();

        return Response<List<AccountsReceivableDocumentDto>>.Success(dtos);
    }
}