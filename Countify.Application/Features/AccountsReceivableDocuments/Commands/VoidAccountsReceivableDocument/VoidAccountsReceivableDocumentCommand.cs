using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.AccountsReceivableDocuments.Commands.VoidAccountsReceivableDocument;

public class VoidAccountsReceivableDocumentCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class VoidAccountsReceivableDocumentCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<VoidAccountsReceivableDocumentCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        VoidAccountsReceivableDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = await unitOfWork.AccountsReceivableDocuments.FirstOrDefaultAsync(
            unitOfWork.AccountsReceivableDocuments.Query()
                .Include(d => d.JournalEntry)
                .Where(d => d.Id == request.Id),
            cancellationToken);
        if (document is null)
            return Response<bool>.NotFound($"Documento por cobrar {request.Id} no encontrado.");

        if (document.IsVoided)
            return Response<bool>.Failure("El documento ya está anulado.");

        if (document.JournalEntry?.PeriodId is Guid periodId &&
            await unitOfWork.AccountingPeriods.ExistsAsync(p => p.Id == periodId && p.IsClosed, cancellationToken))
            return Response<bool>.Failure("El período de la partida generada está cerrado y no puede anularse.");

        document.IsVoided = true;
        if (document.JournalEntry is not null)
            document.JournalEntry.Status = JournalEntryStatus.Voided;

        await unitOfWork.AccountsReceivableDocuments.UpdateAsync(document, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}