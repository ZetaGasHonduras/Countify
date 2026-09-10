using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    IUnitOfWork unitOfWork,
    IMapper mapper)
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
            .ProjectTo<PermissionDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var dto = mapper.Map<RoleDetailDto>(role);
        dto.PermissionCount = permissions.Count;
        dto.Permissions = permissions;

        return Response<RoleDetailDto>.Success(dto);
    }
}