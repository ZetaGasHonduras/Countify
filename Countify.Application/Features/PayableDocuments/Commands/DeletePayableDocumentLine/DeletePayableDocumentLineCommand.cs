using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PayableDocuments.Commands.DeletePayableDocumentLine;

public class DeletePayableDocumentLineCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeletePayableDocumentLineCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePayableDocumentLineCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeletePayableDocumentLineCommand request, CancellationToken cancellationToken)
    {
        var line = await unitOfWork.PayableDocumentLines.GetByIdAsync(request.Id, cancellationToken);
        if (line is null)
            return Response<bool>.NotFound($"Abono {request.Id} no encontrado.");

        await unitOfWork.PayableDocumentLines.DeleteAsync(line, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
