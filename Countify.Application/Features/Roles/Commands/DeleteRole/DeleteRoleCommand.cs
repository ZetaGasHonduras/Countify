using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Roles.Commands.DeleteRole;

public class DeleteRoleCommand : IRequest<Response<bool>>
{
    public string Id { get; set; } = string.Empty;
}

public class DeleteRoleCommandHandler(
    RoleManager<IdentityRole> roleManager,
    UserManager<ApplicationUser> userManager)
    : IRequestHandler<DeleteRoleCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(request.Id);
        if (role is null)
            return Response<bool>.NotFound($"Rol {request.Id} no encontrado.");

        var usersInRole = await userManager.GetUsersInRoleAsync(role.Name!);
        if (usersInRole.Any())
            return Response<bool>.Failure(
                $"No se puede eliminar el rol '{role.Name}' porque tiene usuarios asignados.");

        var result = await roleManager.DeleteAsync(role);

        return !result.Succeeded
            ? Response<bool>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)))
            : Response<bool>.Success(true);
    }
}