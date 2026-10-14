using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountsReceivableDocuments.Commands.DeleteAccountsReceivableDocumentLine;

public class DeleteAccountsReceivableDocumentLineCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteAccountsReceivableDocumentLineCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAccountsReceivableDocumentLineCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteAccountsReceivableDocumentLineCommand request, CancellationToken cancellationToken)
    {
        var line = await unitOfWork.AccountsReceivableDocumentLines.GetByIdAsync(request.Id, cancellationToken);
        if (line is null)
            return Response<bool>.NotFound($"Abono {request.Id} no encontrado.");

        await unitOfWork.AccountsReceivableDocumentLines.DeleteAsync(line, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}