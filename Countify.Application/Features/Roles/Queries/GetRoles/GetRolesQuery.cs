using Countify.Application.Extensions;
using Countify.Application.Features.Roles.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Roles.Queries.GetRoles;

public class GetRolesQuery : RequestParameter, IRequest<PaginatedResponse<List<RoleDto>>>;

public class GetRolesQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetRolesQuery, PaginatedResponse<List<RoleDto>>>
{
    public async Task<PaginatedResponse<List<RoleDto>>> Handle(
        GetRolesQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.Roles.Query()
            .ApplySearch(request.Parameter, x => x.Name!.Contains(request.Parameter!))
            .ApplyOrder(request.Column, request.Order == "desc", x => x.Name!, new()
            {
                ["Name"] = x => x.Name!
            });

        var totalCount = await unitOfWork.Roles.CountAsync(query, cancellationToken);

        if (request.All)
        {
            request.PageNumber = 1;
            request.PageSize = totalCount;
        }

        var roles = await unitOfWork.Roles.ToListAsync(
            query.Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize),
            cancellationToken);

        var dtos = new List<RoleDto>();
        foreach (var role in roles)
        {
            var permissionCount = await unitOfWork.RolePermissions.CountAsync(
                unitOfWork.RolePermissions
                    .Query()
                    .Where(rp => rp.RoleId == role.Id),
                cancellationToken);

            dtos.Add(new RoleDto
            {
                Id = role.Id,
                Name = role.Name!,
                PermissionCount = permissionCount
            });
        }

        return new PaginatedResponse<List<RoleDto>>(dtos, request.PageNumber, request.PageSize, totalCount);
    }
}