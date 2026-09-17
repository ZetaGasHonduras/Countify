using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Projects.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteProjectCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProjectCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await unitOfWork.Projects.GetByIdAsync(request.Id, cancellationToken);
        if (project is null)
            return Response<bool>.NotFound($"Proyecto {request.Id} no encontrado.");

        var isDefault = await unitOfWork.CompanySettings.Query()
            .AnyAsync(s => s.DefaultProjectId == request.Id, cancellationToken);

        if (isDefault)
            return Response<bool>.Failure("No se puede eliminar: es el proyecto predeterminado de la configuración.");

        await unitOfWork.Projects.DeleteAsync(project, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}