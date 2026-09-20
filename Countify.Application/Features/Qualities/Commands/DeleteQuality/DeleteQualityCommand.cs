using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Qualities.Commands.DeleteQuality;

public class DeleteQualityCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteQualityCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteQualityCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteQualityCommand request, CancellationToken cancellationToken)
    {
        var quality = await unitOfWork.Qualities.GetByIdAsync(request.Id, cancellationToken);
        if (quality is null)
            return Response<bool>.NotFound($"Calidad {request.Id} no encontrada.");

        var hasAssignments = await unitOfWork.ProductAccounts.ExistsAsync(
            a => a.QualityId == request.Id, cancellationToken);

        if (hasAssignments)
            return Response<bool>.Failure("No se puede eliminar: la calidad está asignada en cuentas por producto.");

        await unitOfWork.Qualities.DeleteAsync(quality, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}