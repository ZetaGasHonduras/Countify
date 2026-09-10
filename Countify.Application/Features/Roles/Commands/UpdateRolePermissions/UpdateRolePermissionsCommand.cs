using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Roles.Commands.UpdateRolePermissions;

public class UpdateRolePermissionsCommand : IRequest<Response<bool>>
{
    public string RoleId { get; set; } = string.Empty;
    public List<int> PermissionIds { get; set; } = [];
}

public class UpdateRolePermissionsCommandHandler(
    RoleManager<IdentityRole> roleManager,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateRolePermissionsCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateRolePermissionsCommand request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(request.RoleId);
        if (role is null)
            return Response<bool>.NotFound($"Rol {request.RoleId} no encontrado.");

        var validPermissions = await unitOfWork.Permissions.Query()
            .Where(p => request.PermissionIds.Contains(p.Id))
            .Select(p => p.Id)
            .ToListAsync(cancellationToken);

        var invalid = request.PermissionIds.Except(validPermissions).ToList();
        if (invalid.Any())
            return Response<bool>.Failure($"Permisos no válidos: {string.Join(", ", invalid)}");

        // Eliminar permisos actuales
        var current = await unitOfWork.RolePermissions.Query()
            .Where(rp => rp.RoleId == request.RoleId)
            .ToListAsync(cancellationToken);

        foreach (var rp in current)
            await unitOfWork.RolePermissions.DeleteAsync(rp, cancellationToken);

        // Insertar nuevos
        foreach (var permissionId in request.PermissionIds)
            await unitOfWork.RolePermissions.AddAsync(new RolePermission
            {
                RoleId = request.RoleId,
                PermissionId = permissionId
            }, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true);
    }
}