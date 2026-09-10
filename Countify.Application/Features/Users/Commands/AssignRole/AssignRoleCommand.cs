using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Users.Commands.AssignRole;

public class AssignRoleCommand : IRequest<Response<bool>>
{
    public string UserId { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
}

public class AssignRoleCommandHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<AssignRoleCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        AssignRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId);
        if (user is null)
            return Response<bool>.NotFound($"Usuario {request.UserId} no encontrado.");

        var currentRoles = await userManager.GetRolesAsync(user);
        if (currentRoles.Any())
            await userManager.RemoveFromRolesAsync(user, currentRoles);

        var result = await userManager.AddToRoleAsync(user, request.RoleName);

        return !result.Succeeded
            ? Response<bool>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)))
            : Response<bool>.Success(true);
    }
}