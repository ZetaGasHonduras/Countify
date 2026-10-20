using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments.Commands.VoidPayableDocument;

public class VoidPayableDocumentCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class VoidPayableDocumentCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<VoidPayableDocumentCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        VoidPayableDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = await unitOfWork.PayableDocuments.FirstOrDefaultAsync(
            unitOfWork.PayableDocuments.Query()
                .Include(d => d.JournalEntry)
                .Where(d => d.Id == request.Id),
            cancellationToken);
        if (document is null)
            return Response<bool>.NotFound($"Documento por pagar {request.Id} no encontrado.");

        if (document.IsVoided)
            return Response<bool>.Failure("El documento ya está anulado.");

        if (document.JournalEntry?.PeriodId is Guid periodId &&
            await unitOfWork.AccountingPeriods.ExistsAsync(p => p.Id == periodId && p.IsClosed, cancellationToken))
            return Response<bool>.Failure("El período de la partida generada está cerrado y no puede anularse.");

        document.IsVoided = true;
        if (document.JournalEntry is not null)
            document.JournalEntry.Status = JournalEntryStatus.Voided;

        await unitOfWork.PayableDocuments.UpdateAsync(document, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
