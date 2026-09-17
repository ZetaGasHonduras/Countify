using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? GroupId { get; set; }
}

public class CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateProjectCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.Projects.ExistsAsync(
            p => p.Code == request.Code, cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El proyecto '{request.Code}' ya existe.");

        if (request.GroupId is not null)
        {
            var groupExists = await unitOfWork.ProjectGroups.ExistsAsync(
                g => g.Id == request.GroupId.Value, cancellationToken);

            if (!groupExists)
                return Response<Guid>.Failure("El grupo de proyectos indicado no existe.");
        }

        var project = mapper.Map<Project>(request);
        await unitOfWork.Projects.AddAsync(project, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(project.Id, 201);
    }
}