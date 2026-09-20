using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Projects.Commands.DeleteProjectGroup;

public class DeleteProjectGroupCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteProjectGroupCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProjectGroupCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteProjectGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await unitOfWork.ProjectGroups.GetByIdAsync(request.Id, cancellationToken);
        if (group is null)
            return Response<bool>.NotFound($"Grupo {request.Id} no encontrado.");

        var hasProjects = await unitOfWork.Projects.ExistsAsync(
            p => p.GroupId == request.Id, cancellationToken);

        if (hasProjects)
            return Response<bool>.Failure("No se puede eliminar: el grupo tiene proyectos asociados.");

        await unitOfWork.ProjectGroups.DeleteAsync(group, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}