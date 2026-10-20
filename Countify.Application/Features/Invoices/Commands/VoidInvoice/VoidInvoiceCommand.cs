using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Invoices.Commands.VoidInvoice;

public class VoidInvoiceCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public class VoidInvoiceCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<VoidInvoiceCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        VoidInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await unitOfWork.Invoices.Query()
            .Include(i => i.Lines)
            .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

        if (invoice is null)
            return Response<bool>.NotFound($"Factura {request.Id} no encontrada.");

        if (invoice.IsVoided)
            return Response<bool>.Failure("La factura ya está anulada.");

        invoice.IsVoided = true;
        invoice.VoidedAt = DateTime.UtcNow;
        invoice.VoidReason = request.Reason.Trim();

        // Legacy AnularFacturas: genera el documento de anulación (crédito) en CxC
        // solo si la factura tenía su documento por cobrar.
        if (invoice.ReceivableDocumentId is not null)
        {
            var cancelError = await ReceivableLinkHelper.CreateCancellationAsync(
                unitOfWork, invoice, invoice.VoidReason, cancellationToken);
            if (cancelError is not null)
                return Response<bool>.Failure(cancelError);
        }

        await unitOfWork.Invoices.UpdateAsync(invoice, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
