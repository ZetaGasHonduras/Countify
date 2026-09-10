using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Response<bool>>
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string RoleId { get; set; } = string.Empty;
}

public class UpdateUserCommandHandler(
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IMapper mapper)
    : IRequestHandler<UpdateUserCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);
        if (user is null)
            return Response<bool>.NotFound($"Usuario {request.Id} no encontrado.");

        var role = await roleManager.FindByIdAsync(request.RoleId);
        if (role is null)
            return Response<bool>.Failure("Rol no encontrado.");

        mapper.Map(request, user);

        var currentRoles = await userManager.GetRolesAsync(user);

        if (!currentRoles.Contains(role.Name!))
        {
            var removeResponse = await userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResponse.Succeeded)
                return Response<bool>.Failure(string.Join(", ", removeResponse.Errors.Select(e => e.Description)));

            var addRoleResponse = await userManager.AddToRoleAsync(user, role.Name!);
            if (!addRoleResponse.Succeeded)
                return Response<bool>.Failure(string.Join(", ", addRoleResponse.Errors.Select(e => e.Description)));
        }

        var result = await userManager.UpdateAsync(user);
        return !result.Succeeded
            ? Response<bool>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)))
            : Response<bool>.Success(true);
    }
}