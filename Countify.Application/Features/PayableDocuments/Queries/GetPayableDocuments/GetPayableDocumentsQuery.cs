using AutoMapper;
using Countify.Application.Features.PayableDocuments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments.Queries.GetPayableDocuments;

public class GetPayableDocumentsQuery : IRequest<Response<List<PayableDocumentDto>>>;

public class GetPayableDocumentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetPayableDocumentsQuery, Response<List<PayableDocumentDto>>>
{
    public async Task<Response<List<PayableDocumentDto>>> Handle(
        GetPayableDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await unitOfWork.PayableDocuments.ToListAsync(
            unitOfWork.PayableDocuments.Query()
                .Include(d => d.Supplier)
                .Include(d => d.Concept)
                .Include(d => d.Department)
                .Include(d => d.Project)
                .Include(d => d.Currency)
                .Include(d => d.Warehouse)
                .OrderByDescending(d => d.DocumentNo),
            cancellationToken);

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

        var applied = (await unitOfWork.PayableDocumentLines.ToListAsync(
                unitOfWork.PayableDocumentLines.Query()
                    .Where(l => ids.Contains(l.DocumentId)),
                cancellationToken))
            .GroupBy(l => l.DocumentId)
            .ToDictionary(g => g.Key, g => g.Sum(l => l.Amount));

        foreach (var (dto, document) in dtos.Zip(documents))
        {
            var total = Math.Round(document.Amount + document.Tax, 2);

            if (!dto.IsVoided && !dto.IsPayment)
            {
                dto.OutstandingAmount = Math.Round(
                    total - (payments.TryGetValue(document.Id, out var paid) ? paid : 0), 2);
            }

            dto.DifferenceAmount = Math.Round(
                total - (applied.TryGetValue(document.Id, out var abonos) ? abonos : 0), 2);
        }

        return Response<List<PayableDocumentDto>>.Success(dtos);
    }
}
