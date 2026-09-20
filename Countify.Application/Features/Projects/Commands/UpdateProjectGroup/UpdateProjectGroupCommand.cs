using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Projects.Commands.UpdateProjectGroup;

public class UpdateProjectGroupCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class UpdateProjectGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateProjectGroupCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateProjectGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await unitOfWork.ProjectGroups.GetByIdAsync(request.Id, cancellationToken);
        if (group is null)
            return Response<bool>.NotFound($"Grupo {request.Id} no encontrado.");

        var codeInUse = await unitOfWork.ProjectGroups.ExistsAsync(
            g => g.Code == request.Code && g.Id != request.Id, cancellationToken);

        if (codeInUse)
            return Response<bool>.Failure($"El grupo '{request.Code}' ya existe.");

        mapper.Map(request, group);
        await unitOfWork.ProjectGroups.UpdateAsync(group, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}