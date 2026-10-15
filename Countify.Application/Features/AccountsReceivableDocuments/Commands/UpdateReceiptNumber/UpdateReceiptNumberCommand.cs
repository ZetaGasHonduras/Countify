using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateReceiptNumber;

/// <summary>
/// Permite corregir el correlativo de un recibo ya asignado
/// (legacy: edición de <c>NumeroDeRecibo</c> con <c>CorrelativoAsignado</c>).
/// </summary>
public class UpdateReceiptNumberCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public int ReceiptNumber { get; set; }
}

public class UpdateReceiptNumberCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateReceiptNumberCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateReceiptNumberCommand request, CancellationToken cancellationToken)
    {
        if (request.ReceiptNumber <= 0)
            return Response<bool>.Failure("El correlativo de recibo debe ser mayor que cero.");

        var document = await unitOfWork.AccountsReceivableDocuments.FirstOrDefaultAsync(
            unitOfWork.AccountsReceivableDocuments.Query().Where(d => d.Id == request.Id),
            cancellationToken);
        if (document is null)
            return Response<bool>.NotFound($"Documento por cobrar {request.Id} no encontrado.");

        if (document.IsVoided)
            return Response<bool>.Failure("El documento está anulado y no puede modificarse.");

        if (document.ReceiptNumber is null)
            return Response<bool>.Failure("El documento no tiene un correlativo de recibo asignado.");

        if (document.ReceiptNumber == request.ReceiptNumber)
            return Response<bool>.Success(true, 204);

        var duplicated = await unitOfWork.AccountsReceivableDocuments.ExistsAsync(
            d => d.Id != request.Id && d.ReceiptNumber == request.ReceiptNumber,
            cancellationToken);
        if (duplicated)
            return Response<bool>.Failure($"El correlativo de recibo {request.ReceiptNumber} ya está asignado a otro documento.");

        document.ReceiptNumber = request.ReceiptNumber;
        document.ReceiptNumberAssigned = true;

        await unitOfWork.AccountsReceivableDocuments.UpdateAsync(document, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
