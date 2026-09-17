using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Projects.Commands.CreateProjectGroup;

public class CreateProjectGroupCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class CreateProjectGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateProjectGroupCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateProjectGroupCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.ProjectGroups.ExistsAsync(
            g => g.Code == request.Code, cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El grupo '{request.Code}' ya existe.");

        var group = mapper.Map<ProjectGroup>(request);
        await unitOfWork.ProjectGroups.AddAsync(group, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(group.Id, 201);
    }
}