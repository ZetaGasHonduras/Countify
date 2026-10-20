using Countify.Application.Common.Interfaces;
using Countify.Application.Features.PayableDocuments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PayableDocuments.Queries.GetPayableDocumentAttachment;

public class GetPayableDocumentAttachmentQuery
    : IRequest<Response<PayableDocumentAttachmentContentDto>>
{
    public Guid Id { get; set; }
}

public class GetPayableDocumentAttachmentQueryHandler(
    IUnitOfWork unitOfWork,
    IFileStorage fileStorage)
    : IRequestHandler<GetPayableDocumentAttachmentQuery, Response<PayableDocumentAttachmentContentDto>>
{
    public async Task<Response<PayableDocumentAttachmentContentDto>> Handle(
        GetPayableDocumentAttachmentQuery request, CancellationToken cancellationToken)
    {
        var attachment = await unitOfWork.PayableDocumentAttachments.GetByIdAsync(request.Id, cancellationToken);
        if (attachment is null)
            return Response<PayableDocumentAttachmentContentDto>.NotFound($"Adjunto {request.Id} no encontrado.");

        var stream = await fileStorage.OpenReadAsync(attachment.StoragePath, cancellationToken);
        if (stream is null)
            return Response<PayableDocumentAttachmentContentDto>.NotFound("El archivo del adjunto no existe en el almacenamiento.");

        var dto = new PayableDocumentAttachmentContentDto
        {
            FileName = attachment.FileName,
            ContentType = attachment.ContentType,
            Content = stream
        };

        return Response<PayableDocumentAttachmentContentDto>.Success(dto);
    }
}
