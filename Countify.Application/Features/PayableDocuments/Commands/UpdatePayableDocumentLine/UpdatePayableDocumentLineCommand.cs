using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments.Commands.UpdatePayableDocumentLine;

public class UpdatePayableDocumentLineCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
}

public class UpdatePayableDocumentLineCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdatePayableDocumentLineCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdatePayableDocumentLineCommand request, CancellationToken cancellationToken)
    {
        var line = await unitOfWork.PayableDocumentLines.FirstOrDefaultAsync(
            unitOfWork.PayableDocumentLines.Query()
                .Include(l => l.AppliedDocument)
                .Include(l => l.Document)
                .Where(l => l.Id == request.Id),
            cancellationToken);

        if (line is null)
            return Response<bool>.NotFound($"Abono {request.Id} no encontrado.");

        if (line.Document is { IsVoided: true })
            return Response<bool>.Failure("El pago está anulado y no puede modificarse.");

        if (line.AppliedDocument is { IsVoided: true })
            return Response<bool>.Failure("La compra aplicada está anulada.");

        var paidElsewhere = await unitOfWork.PayableDocumentLines.ToListAsync(
            unitOfWork.PayableDocumentLines.Query()
                .Where(l => l.AppliedDocumentId == line.AppliedDocumentId && l.Id != line.Id),
            cancellationToken);

        var outstanding = Math.Round(
            line.AppliedDocument!.Total() - paidElsewhere.Sum(l => l.Amount), 2);

        if (request.Amount <= 0)
            return Response<bool>.Failure("El abono debe ser mayor que cero.");

        if (request.Amount > outstanding)
            return Response<bool>.Failure($"El abono supera el saldo pendiente de la compra ({outstanding}).");

        line.Amount = Math.Round(request.Amount, 2);
        await unitOfWork.PayableDocumentLines.UpdateAsync(line, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
