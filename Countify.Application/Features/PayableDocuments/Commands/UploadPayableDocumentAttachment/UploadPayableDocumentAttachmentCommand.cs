using Countify.Application.Common.Interfaces;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PayableDocuments.Commands.UploadPayableDocumentAttachment;

public class UploadPayableDocumentAttachmentCommand : IRequest<Response<Guid>>
{
    public Guid DocumentId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public long Size { get; set; }
    public Stream Content { get; set; } = Stream.Null;
    public string? UploadedBy { get; set; }
}

public class UploadPayableDocumentAttachmentCommandHandler(
    IUnitOfWork unitOfWork,
    IFileStorage fileStorage)
    : IRequestHandler<UploadPayableDocumentAttachmentCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        UploadPayableDocumentAttachmentCommand request, CancellationToken cancellationToken)
    {
        var document = await unitOfWork.PayableDocuments.GetByIdAsync(request.DocumentId, cancellationToken);
        if (document is null)
            return Response<Guid>.NotFound($"Documento por pagar {request.DocumentId} no encontrado.");

        if (string.IsNullOrWhiteSpace(request.FileName))
            return Response<Guid>.Failure("El nombre del archivo es obligatorio.");

        var folder = $"payable-documents/{request.DocumentId}";
        var storagePath = await fileStorage.SaveAsync(request.Content, request.FileName, folder, cancellationToken);

        var attachment = new PayableDocumentAttachment
        {
            DocumentId = request.DocumentId,
            FileName = request.FileName,
            ContentType = request.ContentType,
            Size = request.Size,
            StoragePath = storagePath,
            UploadedOn = DateTime.UtcNow,
            UploadedBy = request.UploadedBy
        };

        await unitOfWork.PayableDocumentAttachments.AddAsync(attachment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(attachment.Id, 201);
    }
}
