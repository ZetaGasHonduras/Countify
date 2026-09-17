using AutoMapper;
using Countify.Application.Extensions;
using Countify.Application.Features.Projects.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Projects.Queries.GetProjects;

public class GetProjectsQuery : RequestParameter, IRequest<PaginatedResponse<List<ProjectDto>>>
{
    public string? Search { get; set; }
}

public class GetProjectsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetProjectsQuery, PaginatedResponse<List<ProjectDto>>>
{
    public async Task<PaginatedResponse<List<ProjectDto>>> Handle(
        GetProjectsQuery request, CancellationToken cancellationToken)
    {
        if (request.PageSize <= 0) request.PageSize = 10;
        if (request.PageNumber < 0) request.PageNumber = 0;

        var search = request.Search ?? request.Parameter;

        var query = unitOfWork.Projects.Query()
            .ApplySearch(search, x => x.Code.Contains(search!) || x.Name.Contains(search!))
            .ApplyOrder(request.Column, request.Order == "desc", x => x.Code, new()
            {
                ["Code"] = x => x.Code,
                ["Name"] = x => x.Name
            });

        var totalCount = await unitOfWork.Projects.CountAsync(query, cancellationToken);

        if (request.All)
        {
            request.PageNumber = 0;
            request.PageSize = totalCount == 0 ? 1 : totalCount;
        }

        var projects = await unitOfWork.Projects.ToListAsync(
            query
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize),
            cancellationToken);

        var dtos = mapper.Map<List<ProjectDto>>(projects);

        return new PaginatedResponse<List<ProjectDto>>(
            dtos, request.PageNumber, request.PageSize, totalCount);
    }
}