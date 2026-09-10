using Countify.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest<Response<string>>
{
    public string Name { get; set; } = string.Empty;
}

public class CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
    : IRequestHandler<CreateRoleCommand, Response<string>>
{
    public async Task<Response<string>> Handle(
        CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var exists = await roleManager.RoleExistsAsync(request.Name);
        if (exists)
            return Response<string>.Failure($"El rol '{request.Name}' ya existe.");

        var role = new IdentityRole(request.Name);
        var result = await roleManager.CreateAsync(role);

        return !result.Succeeded
            ? Response<string>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)))
            : Response<string>.Success(role.Id, 201);
    }
}