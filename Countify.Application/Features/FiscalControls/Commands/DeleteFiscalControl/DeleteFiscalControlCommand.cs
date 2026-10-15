using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.FiscalControls.Commands.DeleteFiscalControl;

public class DeleteFiscalControlCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteFiscalControlCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteFiscalControlCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteFiscalControlCommand request, CancellationToken cancellationToken)
    {
        var control = await unitOfWork.FiscalControls.GetByIdAsync(request.Id, cancellationToken);
        if (control is null)
            return Response<bool>.NotFound($"Control fiscal {request.Id} no encontrado.");

        var inUse = await unitOfWork.AccountsReceivableDocuments.ExistsAsync(
            d => d.FiscalControlId == request.Id, cancellationToken);

        if (inUse)
            return Response<bool>.Failure("No se puede eliminar: el control fiscal está asociado a documentos.");

        await unitOfWork.FiscalControls.DeleteAsync(control, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
