using Countify.Application.Common.Interfaces;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountsReceivableDocuments.Commands.UploadAccountsReceivableDocumentAttachment;

public class UploadAccountsReceivableDocumentAttachmentCommand : IRequest<Response<Guid>>
{
    public Guid DocumentId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public long Size { get; set; }
    public Stream Content { get; set; } = Stream.Null;
    public string? UploadedBy { get; set; }
}

public class UploadAccountsReceivableDocumentAttachmentCommandHandler(
    IUnitOfWork unitOfWork,
    IFileStorage fileStorage)
    : IRequestHandler<UploadAccountsReceivableDocumentAttachmentCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        UploadAccountsReceivableDocumentAttachmentCommand request, CancellationToken cancellationToken)
    {
        var document = await unitOfWork.AccountsReceivableDocuments.GetByIdAsync(request.DocumentId, cancellationToken);
        if (document is null)
            return Response<Guid>.NotFound($"Documento por cobrar {request.DocumentId} no encontrado.");

        if (string.IsNullOrWhiteSpace(request.FileName))
            return Response<Guid>.Failure("El nombre del archivo es obligatorio.");

        var folder = $"accounts-receivable/{request.DocumentId}";
        var storagePath = await fileStorage.SaveAsync(request.Content, request.FileName, folder, cancellationToken);

        var attachment = new AccountsReceivableDocumentAttachment
        {
            DocumentId = request.DocumentId,
            FileName = request.FileName,
            ContentType = request.ContentType,
            Size = request.Size,
            StoragePath = storagePath,
            UploadedOn = DateTime.UtcNow,
            UploadedBy = request.UploadedBy
        };

        await unitOfWork.AccountsReceivableDocumentAttachments.AddAsync(attachment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(attachment.Id, 201);
    }
}
