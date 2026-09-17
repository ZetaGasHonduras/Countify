using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.DocumentTypes.Commands.DeleteDocumentType;

public class DeleteDocumentTypeCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteDocumentTypeCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteDocumentTypeCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
    {
        var documentType = await unitOfWork.DocumentTypes.GetByIdAsync(request.Id, cancellationToken);
        if (documentType is null)
            return Response<bool>.NotFound($"Tipo de documento {request.Id} no encontrado.");

        if (documentType.IsDefault)
            return Response<bool>.Failure("No se puede eliminar el tipo de documento predeterminado.");

        var inUse = await unitOfWork.JournalEntries.ExistsAsync(
            e => e.TypeId == request.Id, cancellationToken);

        if (inUse)
            return Response<bool>.Failure("No se puede eliminar: el tipo de documento está en uso por partidas contables.");

        await unitOfWork.DocumentTypes.DeleteAsync(documentType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}