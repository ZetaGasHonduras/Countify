using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Response<bool>>
{
    public string Id { get; set; } = string.Empty;
}

public class DeleteUserCommandHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<DeleteUserCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);
        if (user is null)
            return Response<bool>.NotFound($"Usuario {request.Id} no encontrado.");

        // Soft delete
        user.IsActive = false;

        var result = await userManager.UpdateAsync(user);
        return !result.Succeeded
            ? Response<bool>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)))
            : Response<bool>.Success(true);
    }
}