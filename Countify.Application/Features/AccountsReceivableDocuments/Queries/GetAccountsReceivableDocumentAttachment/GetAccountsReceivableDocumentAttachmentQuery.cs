using Countify.Application.Common.Interfaces;
using Countify.Application.Features.AccountsReceivableDocuments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocumentAttachment;

public class GetAccountsReceivableDocumentAttachmentQuery
    : IRequest<Response<AccountsReceivableDocumentAttachmentContentDto>>
{
    public Guid Id { get; set; }
}

public class GetAccountsReceivableDocumentAttachmentQueryHandler(
    IUnitOfWork unitOfWork,
    IFileStorage fileStorage)
    : IRequestHandler<GetAccountsReceivableDocumentAttachmentQuery, Response<AccountsReceivableDocumentAttachmentContentDto>>
{
    public async Task<Response<AccountsReceivableDocumentAttachmentContentDto>> Handle(
        GetAccountsReceivableDocumentAttachmentQuery request, CancellationToken cancellationToken)
    {
        var attachment = await unitOfWork.AccountsReceivableDocumentAttachments.GetByIdAsync(request.Id, cancellationToken);
        if (attachment is null)
            return Response<AccountsReceivableDocumentAttachmentContentDto>.NotFound($"Adjunto {request.Id} no encontrado.");

        var stream = await fileStorage.OpenReadAsync(attachment.StoragePath, cancellationToken);
        if (stream is null)
            return Response<AccountsReceivableDocumentAttachmentContentDto>.NotFound("El archivo del adjunto no existe en el almacenamiento.");

        var dto = new AccountsReceivableDocumentAttachmentContentDto
        {
            FileName = attachment.FileName,
            ContentType = attachment.ContentType,
            Content = stream
        };

        return Response<AccountsReceivableDocumentAttachmentContentDto>.Success(dto);
    }
}
