using AutoMapper;
using Countify.Application.Features.PayableDocuments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments.Queries.GetPayableDocumentById;

public class GetPayableDocumentByIdQuery : IRequest<Response<PayableDocumentDto>>
{
    public Guid Id { get; set; }
}

public class GetPayableDocumentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetPayableDocumentByIdQuery, Response<PayableDocumentDto>>
{
    public async Task<Response<PayableDocumentDto>> Handle(
        GetPayableDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        var document = await unitOfWork.PayableDocuments.FirstOrDefaultAsync(
            unitOfWork.PayableDocuments.Query()
                .Include(d => d.Supplier)
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
                .Include(d => d.Attachments)
                .Where(d => d.Id == request.Id),
            cancellationToken);

        if (document is null)
            return Response<PayableDocumentDto>.NotFound($"Documento por pagar {request.Id} no encontrado.");

        var dto = mapper.Map<PayableDocumentDto>(document);
        var total = Math.Round(document.Amount + document.Tax, 2);

        decimal paid = 0, applied = 0;
        if (document.Lines.Count > 0)
        {
            var appliedIds = document.Lines.Select(l => l.AppliedDocumentId).ToList();
            var outstandingPerApplied = (await unitOfWork.PayableDocumentLines.ToListAsync(
                    unitOfWork.PayableDocumentLines.Query()
                        .Where(l => appliedIds.Contains(l.AppliedDocumentId)),
                    cancellationToken))
                .GroupBy(l => l.AppliedDocumentId)
                .ToDictionary(g => g.Key, g => g.Sum(l => l.Amount));

            foreach (var (lineDto, line) in dto.Lines.Zip(document.Lines))
            {
                // AppliedAmount ya es el total (Amount + Tax) según el perfil.
                if (outstandingPerApplied.TryGetValue(line.AppliedDocumentId, out var abonado))
                    lineDto.AppliedOutstandingAmount = Math.Round(lineDto.AppliedAmount - abonado, 2);
                applied += line.Amount;
            }
        }
        else
        {
            paid = (await unitOfWork.PayableDocumentLines.ToListAsync(
                    unitOfWork.PayableDocumentLines.Query()
                        .Where(l => l.AppliedDocumentId == request.Id),
                    cancellationToken))
                .Sum(l => l.Amount);
        }

        dto.DifferenceAmount = Math.Round(total - applied, 2);
        if (!dto.IsVoided && !dto.IsPayment)
            dto.OutstandingAmount = Math.Round(total - paid, 2);

        return Response<PayableDocumentDto>.Success(dto);
    }
}
