using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments.Commands.CreatePayableDocumentLines;

public class CreatePayableDocumentLinesCommand : IRequest<Response<bool>>
{
    public Guid DocumentId { get; set; }
    public List<LineItem> Lines { get; set; } = [];

    public class LineItem
    {
        public Guid AppliedDocumentId { get; set; }
        public decimal? Amount { get; set; }
    }
}

public class CreatePayableDocumentLinesCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePayableDocumentLinesCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        CreatePayableDocumentLinesCommand request, CancellationToken cancellationToken)
    {
        var payment = await unitOfWork.PayableDocuments.FirstOrDefaultAsync(
            unitOfWork.PayableDocuments.Query()
                .Include(d => d.Concept)
                .Where(d => d.Id == request.DocumentId),
            cancellationToken);

        if (payment is null)
            return Response<bool>.NotFound($"Documento por pagar {request.DocumentId} no encontrado.");

        if (payment.IsVoided)
            return Response<bool>.Failure("El documento está anulado y no puede aplicarse.");

        if (payment.Concept is null || payment.Concept.Type != PayableConceptType.Credit)
            return Response<bool>.Failure("Solo los documentos de crédito (pagos) pueden aplicar facturas.");

        var appliedIds = request.Lines.Select(l => l.AppliedDocumentId).Distinct().ToList();
        if (appliedIds.Count != request.Lines.Count)
            return Response<bool>.Failure("No se puede aplicar la misma factura más de una vez.");

        var appliedDocuments = await unitOfWork.PayableDocuments.ToListAsync(
            unitOfWork.PayableDocuments.Query()
                .Include(d => d.Concept)
                .Where(d => appliedIds.Contains(d.Id)),
            cancellationToken);

        var appliedById = appliedDocuments.ToDictionary(d => d.Id);

        var alreadyApplied = await unitOfWork.PayableDocumentLines.ToListAsync(
            unitOfWork.PayableDocumentLines.Query()
                .Where(l => l.DocumentId == request.DocumentId && appliedIds.Contains(l.AppliedDocumentId)),
            cancellationToken);
        if (alreadyApplied.Count > 0)
            return Response<bool>.Failure("Una de las facturas seleccionadas ya está aplicada a este pago.");

        var totalPayments = (await unitOfWork.PayableDocumentLines.ToListAsync(
                unitOfWork.PayableDocumentLines.Query()
                    .Where(l => appliedIds.Contains(l.AppliedDocumentId)),
                cancellationToken))
            .GroupBy(l => l.AppliedDocumentId)
            .ToDictionary(g => g.Key, g => g.Sum(l => l.Amount));

        var abonadoEnEstePago = 0m;
        List<PayableDocumentLine> linesToAdd = [];

        foreach (var item in request.Lines)
        {
            if (!appliedById.TryGetValue(item.AppliedDocumentId, out var applied))
                return Response<bool>.Failure($"El documento por pagar {item.AppliedDocumentId} no existe.");

            if (applied.IsVoided || applied.Concept is null || applied.Concept.Type != PayableConceptType.Debit)
                return Response<bool>.Failure("Solo pueden aplicarse compras/facturas (documentos de débito) no anuladas.");

            if (applied.SupplierId != payment.SupplierId)
                return Response<bool>.Failure($"La compra {applied.DocumentNo} pertenece a otro proveedor.");

            var outstanding = Math.Round(
                applied.Total() - (totalPayments.TryGetValue(applied.Id, out var paid) ? paid : 0), 2);
            if (outstanding <= 0)
                return Response<bool>.Failure($"La compra {applied.DocumentNo} ya no tiene saldo pendiente.");

            var remaining = Math.Max(0, Math.Round(payment.Total() - abonadoEnEstePago, 2));
            var amount = item.Amount ?? 0m;

            if (amount <= 0)
                amount = Math.Min(outstanding, remaining);
            else if (amount > outstanding)
                return Response<bool>.Failure($"El abono para la compra {applied.DocumentNo} supera su saldo pendiente ({outstanding}).");

            if (amount <= 0)
                return Response<bool>.Failure($"El abono para la compra {applied.DocumentNo} debe ser mayor que cero.");

            linesToAdd.Add(new PayableDocumentLine
            {
                DocumentId = payment.Id,
                AppliedDocumentId = applied.Id,
                Amount = Math.Round(amount, 2)
            });

            abonadoEnEstePago += amount;
        }

        await unitOfWork.PayableDocumentLines.AddRangeAsync(linesToAdd, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
