using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? GroupId { get; set; }
}

public class UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateProjectCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await unitOfWork.Projects.GetByIdAsync(request.Id, cancellationToken);
        if (project is null)
            return Response<bool>.NotFound($"Proyecto {request.Id} no encontrado.");

        var codeInUse = await unitOfWork.Projects.ExistsAsync(
            p => p.Code == request.Code && p.Id != request.Id, cancellationToken);

        if (codeInUse)
            return Response<bool>.Failure($"El proyecto '{request.Code}' ya existe.");

        if (request.GroupId is not null)
        {
            var groupExists = await unitOfWork.ProjectGroups.ExistsAsync(
                g => g.Id == request.GroupId.Value, cancellationToken);

            if (!groupExists)
                return Response<bool>.Failure("El grupo de proyectos indicado no existe.");
        }

        mapper.Map(request, project);
        await unitOfWork.Projects.UpdateAsync(project, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}