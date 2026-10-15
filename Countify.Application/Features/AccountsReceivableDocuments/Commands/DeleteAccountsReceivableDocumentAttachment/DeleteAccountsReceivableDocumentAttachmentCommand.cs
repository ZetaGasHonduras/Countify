using Countify.Application.Common.Interfaces;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountsReceivableDocuments.Commands.DeleteAccountsReceivableDocumentAttachment;

public class DeleteAccountsReceivableDocumentAttachmentCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteAccountsReceivableDocumentAttachmentCommandHandler(
    IUnitOfWork unitOfWork,
    IFileStorage fileStorage)
    : IRequestHandler<DeleteAccountsReceivableDocumentAttachmentCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteAccountsReceivableDocumentAttachmentCommand request, CancellationToken cancellationToken)
    {
        var attachment = await unitOfWork.AccountsReceivableDocumentAttachments.GetByIdAsync(request.Id, cancellationToken);
        if (attachment is null)
            return Response<bool>.NotFound($"Adjunto {request.Id} no encontrado.");

        await fileStorage.DeleteAsync(attachment.StoragePath, cancellationToken);
        await unitOfWork.AccountsReceivableDocumentAttachments.DeleteAsync(attachment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
