using AutoMapper;
using Countify.Application.Features.Projects.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Projects.Queries.GetProjectGroups;

public class GetProjectGroupsQuery : IRequest<Response<List<ProjectGroupDto>>>;

public class GetProjectGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetProjectGroupsQuery, Response<List<ProjectGroupDto>>>
{
    public async Task<Response<List<ProjectGroupDto>>> Handle(
        GetProjectGroupsQuery request, CancellationToken cancellationToken)
    {
        var groups = await unitOfWork.ProjectGroups.ToListAsync(
            unitOfWork.ProjectGroups.Query().OrderBy(g => g.Name),
            cancellationToken);

        return Response<List<ProjectGroupDto>>.Success(
            mapper.Map<List<ProjectGroupDto>>(groups));
    }
}