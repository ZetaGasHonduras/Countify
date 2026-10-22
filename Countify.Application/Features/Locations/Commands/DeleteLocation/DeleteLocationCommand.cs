using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Locations.Commands.DeleteLocation;

public class DeleteLocationCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteLocationCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteLocationCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await unitOfWork.Locations.GetByIdAsync(request.Id, cancellationToken);
        if (location is null)
            return Response<bool>.NotFound($"Ubicación {request.Id} no encontrada.");

        if (location.IsDefault)
            return Response<bool>.Failure("No se puede eliminar la ubicación predeterminada.");

        // Etapa 2 añadirá la validación de movimientos que referencian la ubicación.
        await unitOfWork.Locations.DeleteAsync(location, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
