using Countify.Application.Common.Interfaces;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PayableDocuments.Commands.DeletePayableDocumentAttachment;

public class DeletePayableDocumentAttachmentCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeletePayableDocumentAttachmentCommandHandler(
    IUnitOfWork unitOfWork,
    IFileStorage fileStorage)
    : IRequestHandler<DeletePayableDocumentAttachmentCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeletePayableDocumentAttachmentCommand request, CancellationToken cancellationToken)
    {
        var attachment = await unitOfWork.PayableDocumentAttachments.GetByIdAsync(request.Id, cancellationToken);
        if (attachment is null)
            return Response<bool>.NotFound($"Adjunto {request.Id} no encontrado.");

        await fileStorage.DeleteAsync(attachment.StoragePath, cancellationToken);
        await unitOfWork.PayableDocumentAttachments.DeleteAsync(attachment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
