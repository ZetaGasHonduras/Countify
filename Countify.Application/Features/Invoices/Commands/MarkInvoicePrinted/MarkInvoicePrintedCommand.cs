using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Invoices.Commands.MarkInvoicePrinted;

/// <summary>
/// Legacy "Guardar e Imprimir" (F8): marca <c>Impreso</c>, lo que congela la factura.
/// </summary>
public class MarkInvoicePrintedCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class MarkInvoicePrintedCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<MarkInvoicePrintedCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        MarkInvoicePrintedCommand request, CancellationToken cancellationToken)
    {
        var invoice = await unitOfWork.Invoices.GetByIdAsync(request.Id, cancellationToken);
        if (invoice is null)
            return Response<bool>.NotFound($"Factura {request.Id} no encontrada.");

        if (invoice.IsVoided)
            return Response<bool>.Failure("La factura está anulada.");

        if (!invoice.IsPrinted)
        {
            invoice.IsPrinted = true;
            invoice.PrintedAt = DateTime.UtcNow;
            await unitOfWork.Invoices.UpdateAsync(invoice, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return Response<bool>.Success(true, 204);
    }
}
