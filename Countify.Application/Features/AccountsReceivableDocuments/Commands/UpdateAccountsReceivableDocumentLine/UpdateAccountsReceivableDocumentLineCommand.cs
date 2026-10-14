using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateAccountsReceivableDocumentLine;

public class UpdateAccountsReceivableDocumentLineCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
}

public class UpdateAccountsReceivableDocumentLineCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateAccountsReceivableDocumentLineCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateAccountsReceivableDocumentLineCommand request, CancellationToken cancellationToken)
    {
        var line = await unitOfWork.AccountsReceivableDocumentLines.FirstOrDefaultAsync(
            unitOfWork.AccountsReceivableDocumentLines.Query()
                .Include(l => l.AppliedDocument)
                .Include(l => l.Document)
                .Where(l => l.Id == request.Id),
            cancellationToken);

        if (line is null)
            return Response<bool>.NotFound($"Abono {request.Id} no encontrado.");

        if (line.Document is { IsVoided: true })
            return Response<bool>.Failure("El recibo está anulado y no puede modificarse.");

        if (line.AppliedDocument is { IsVoided: true })
            return Response<bool>.Failure("La factura aplicada está anulada.");

        var paidElsewhere = await unitOfWork.AccountsReceivableDocumentLines.ToListAsync(
            unitOfWork.AccountsReceivableDocumentLines.Query()
                .Where(l => l.AppliedDocumentId == line.AppliedDocumentId && l.Id != line.Id),
            cancellationToken);

        var outstanding = Math.Round(
            line.AppliedDocument!.Amount - paidElsewhere.Sum(l => l.Amount), 2);

        if (request.Amount <= 0)
            return Response<bool>.Failure("El abono debe ser mayor que cero.");

        if (request.Amount > outstanding)
            return Response<bool>.Failure($"El abono supera el saldo pendiente de la factura ({outstanding}).");

        line.Amount = Math.Round(request.Amount, 2);
        await unitOfWork.AccountsReceivableDocumentLines.UpdateAsync(line, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}