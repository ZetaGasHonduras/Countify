using Countify.Application.Features.Roles.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQuery : IRequest<Response<RoleDetailDto>>
{
    public string Id { get; set; } = string.Empty;
}

public class GetRoleByIdQueryHandler(
    RoleManager<IdentityRole> roleManager,
    IUnitOfWork unitOfWork)
    : IRequestHandler<GetRoleByIdQuery, Response<RoleDetailDto>>
{
    public async Task<Response<RoleDetailDto>> Handle(
        GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(request.Id);
        if (role is null)
            return Response<RoleDetailDto>.NotFound($"Rol {request.Id} no encontrado.");

        var permissions = await unitOfWork.RolePermissions.Query()
            .Where(rp => rp.RoleId == role.Id)
            .Include(rp => rp.Permission)
            .Select(rp => new PermissionDto
            {
                Id = rp.Permission!.Id,
                Name = rp.Permission.Name,
                Description = rp.Permission.Description
            })
            .ToListAsync(cancellationToken);

        return Response<RoleDetailDto>.Success(new RoleDetailDto
        {
            Id = role.Id,
            Name = role.Name!,
            PermissionCount = permissions.Count,
            Permissions = permissions
        });
    }
}