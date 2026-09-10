using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Users.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<Response<bool>>
{
    public string Id { get; set; } = string.Empty;
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}

public class ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<ChangePasswordCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);
        if (user is null)
            return Response<bool>.NotFound($"Usuario {request.Id} no encontrado.");

        var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

        return !result.Succeeded
            ? Response<bool>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)))
            : Response<bool>.Success(true);
    }
}