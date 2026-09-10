using Countify.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Roles.Commands.UpdateRole;

public class UpdateRoleCommand : IRequest<Response<bool>>
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class UpdateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
    : IRequestHandler<UpdateRoleCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(request.Id);
        if (role is null)
            return Response<bool>.NotFound($"Rol {request.Id} no encontrado.");

        var nameExists = await roleManager.RoleExistsAsync(request.Name);
        if (nameExists && role.Name != request.Name)
            return Response<bool>.Failure($"El nombre '{request.Name}' ya está en uso.");

        role.Name = request.Name;

        var result = await roleManager.UpdateAsync(role);

        return !result.Succeeded
            ? Response<bool>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)))
            : Response<bool>.Success(true);
    }
}