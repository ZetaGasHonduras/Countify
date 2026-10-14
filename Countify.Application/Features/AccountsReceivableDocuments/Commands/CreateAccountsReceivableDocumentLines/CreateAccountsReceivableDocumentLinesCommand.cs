using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.AccountsReceivableDocuments.Commands.CreateAccountsReceivableDocumentLines;

public class CreateAccountsReceivableDocumentLinesCommand : IRequest<Response<bool>>
{
    public Guid DocumentId { get; set; }
    public List<LineItem> Lines { get; set; } = [];

    public class LineItem
    {
        public Guid AppliedDocumentId { get; set; }
        public decimal? Amount { get; set; }
    }
}

public class CreateAccountsReceivableDocumentLinesCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateAccountsReceivableDocumentLinesCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        CreateAccountsReceivableDocumentLinesCommand request, CancellationToken cancellationToken)
    {
        var receipt = await unitOfWork.AccountsReceivableDocuments.FirstOrDefaultAsync(
            unitOfWork.AccountsReceivableDocuments.Query()
                .Include(d => d.Concept)
                .Where(d => d.Id == request.DocumentId),
            cancellationToken);

        if (receipt is null)
            return Response<bool>.NotFound($"Documento por cobrar {request.DocumentId} no encontrado.");

        if (receipt.IsVoided)
            return Response<bool>.Failure("El documento está anulado y no puede aplicarse.");

        if (receipt.Concept is null || receipt.Concept.Type != AccountsReceivableConceptType.Credit)
            return Response<bool>.Failure("Solo los documentos de crédito (recibos) pueden aplicar pagos.");

        var appliedIds = request.Lines.Select(l => l.AppliedDocumentId).Distinct().ToList();
        if (appliedIds.Count != request.Lines.Count)
            return Response<bool>.Failure("No se puede aplicar el mismo documento más de una vez.");

        var appliedDocuments = await unitOfWork.AccountsReceivableDocuments.ToListAsync(
            unitOfWork.AccountsReceivableDocuments.Query()
                .Include(d => d.Concept)
                .Where(d => appliedIds.Contains(d.Id)),
            cancellationToken);

        var appliedById = appliedDocuments.ToDictionary(d => d.Id);

        var alreadyApplied = await unitOfWork.AccountsReceivableDocumentLines.ToListAsync(
            unitOfWork.AccountsReceivableDocumentLines.Query()
                .Where(l => l.DocumentId == request.DocumentId && appliedIds.Contains(l.AppliedDocumentId)),
            cancellationToken);
        if (alreadyApplied.Count > 0)
            return Response<bool>.Failure("Uno de los documentos seleccionados ya está aplicado a este recibo.");

        var totalPayments = (await unitOfWork.AccountsReceivableDocumentLines.ToListAsync(
                unitOfWork.AccountsReceivableDocumentLines.Query()
                    .Where(l => appliedIds.Contains(l.AppliedDocumentId)),
                cancellationToken))
            .GroupBy(l => l.AppliedDocumentId)
            .ToDictionary(g => g.Key, g => g.Sum(l => l.Amount));

        var abonadoEnEsteRecibo = 0m;
        List<AccountsReceivableDocumentLine> linesToAdd = [];

        foreach (var item in request.Lines)
        {
            if (!appliedById.TryGetValue(item.AppliedDocumentId, out var applied))
                return Response<bool>.Failure($"El documento por cobrar {item.AppliedDocumentId} no existe.");

            if (applied.IsVoided || applied.Concept is null || applied.Concept.Type != AccountsReceivableConceptType.Debit)
                return Response<bool>.Failure("Solo pueden aplicarse facturas (documentos de débito) no anuladas.");

            if (applied.CustomerId != receipt.CustomerId)
                return Response<bool>.Failure($"La factura {applied.DocumentNo} pertenece a otro cliente.");

            var outstanding = Math.Round(
                applied.Amount - (totalPayments.TryGetValue(applied.Id, out var paid) ? paid : 0), 2);
            if (outstanding <= 0)
                return Response<bool>.Failure($"La factura {applied.DocumentNo} ya no tiene saldo pendiente.");

            var remaining = Math.Max(0, Math.Round(receipt.Amount - abonadoEnEsteRecibo, 2));
            var amount = item.Amount ?? 0m;

            if (amount <= 0)
                amount = Math.Min(outstanding, remaining);
            else if (amount > outstanding)
                return Response<bool>.Failure($"El abono para la factura {applied.DocumentNo} supera su saldo pendiente ({outstanding}).");

            if (amount <= 0)
                return Response<bool>.Failure($"El abono para la factura {applied.DocumentNo} debe ser mayor que cero.");

            linesToAdd.Add(new AccountsReceivableDocumentLine
            {
                DocumentId = receipt.Id,
                AppliedDocumentId = applied.Id,
                Amount = Math.Round(amount, 2)
            });

            abonadoEnEsteRecibo += amount;
        }

        await unitOfWork.AccountsReceivableDocumentLines.AddRangeAsync(linesToAdd, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}