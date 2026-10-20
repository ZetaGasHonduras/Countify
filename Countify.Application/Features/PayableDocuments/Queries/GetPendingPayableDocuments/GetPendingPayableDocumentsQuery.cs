using AutoMapper;
using Countify.Application.Features.PayableDocuments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments.Queries.GetPendingPayableDocuments;

public class GetPendingPayableDocumentsQuery
    : IRequest<Response<List<PayableDocumentDto>>>
{
    public Guid SupplierId { get; set; }
    public List<Guid> ExcludeDocumentIds { get; set; } = [];
}

public class GetPendingPayableDocumentsQueryHandler(
    IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetPendingPayableDocumentsQuery, Response<List<PayableDocumentDto>>>
{
    public async Task<Response<List<PayableDocumentDto>>> Handle(
        GetPendingPayableDocumentsQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.PayableDocuments.Query()
            .Include(d => d.Supplier)
            .Include(d => d.Concept)
            .Include(d => d.Currency)
            .Where(d => d.SupplierId == request.SupplierId
                && !d.IsVoided
                && d.Concept != null
                && d.Concept.Type == PayableConceptType.Debit
                && d.Amount > 0);

        if (request.ExcludeDocumentIds.Count > 0)
        {
            query = query.Where(d => !request.ExcludeDocumentIds.Contains(d.Id));
        }

        var documents = await unitOfWork.PayableDocuments.ToListAsync(
            query.OrderBy(d => d.DocumentNo), cancellationToken);

        var dtos = mapper.Map<List<PayableDocumentDto>>(documents);

        if (documents.Count == 0)
            return Response<List<PayableDocumentDto>>.Success(dtos);

        var ids = documents.Select(d => d.Id).ToList();
        var payments = (await unitOfWork.PayableDocumentLines.ToListAsync(
                unitOfWork.PayableDocumentLines.Query()
                    .Where(l => ids.Contains(l.AppliedDocumentId)),
                cancellationToken))
            .GroupBy(l => l.AppliedDocumentId)
            .ToDictionary(g => g.Key, g => g.Sum(l => l.Amount));

        foreach (var (dto, document) in dtos.Zip(documents))
        {
            dto.OutstandingAmount = Math.Round(
                Math.Round(document.Amount + document.Tax, 2)
                - (payments.TryGetValue(document.Id, out var paid) ? paid : 0), 2);
        }

        dtos = dtos.Where(d => d.OutstandingAmount > 0).ToList();

        return Response<List<PayableDocumentDto>>.Success(dtos);
    }
}
