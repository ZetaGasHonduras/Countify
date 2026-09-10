using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Response<string>>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string RoleId { get; set; } = string.Empty;
}

public class CreateUserCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    : IRequestHandler<CreateUserCommand, Response<string>>
{
    public async Task<Response<string>> Handle(
        CreateUserCommand request, CancellationToken cancellationToken)
    {
        var emailExists = await userManager.FindByEmailAsync(request.Email);
        if (emailExists is not null)
            return Response<string>.Failure("El correo ya está registrado.");

        var userNameExists = await userManager.FindByNameAsync(request.Username);
        if (userNameExists is not null)
            return Response<string>.Failure("El nombre de usuario ya está en uso.");

        var role = await roleManager.FindByIdAsync(request.RoleId);

        if (role is null)
            return Response<string>.Failure("Rol no encontrado.");

        var user = new ApplicationUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Username,
            PhoneNumber = request.Phone,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        var createResponse = await userManager.CreateAsync(user, request.Password);
        if (!createResponse.Succeeded)
            return Response<string>.Failure(string.Join(", ", createResponse.Errors.Select(e => e.Description)));

        var addRoleResponse = await userManager.AddToRoleAsync(
            user,
            role.Name!);

        return !addRoleResponse.Succeeded
            ? Response<string>.Failure(string.Join(", ", addRoleResponse.Errors.Select(e => e.Description)))
            : Response<string>.Success(user.Id, "User created successfully.");
    }
}