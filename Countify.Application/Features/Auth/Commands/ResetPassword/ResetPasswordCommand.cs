using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Auth.Commands.ResetPassword;

public record ResetPasswordCommand(string Email, string Token, string NewPassword) : IRequest<Response<bool>>;

public class ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<ResetPasswordCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null || !user.IsActive)
            return Response<bool>.Failure("Solicitud inválida.", 400);

        var token = Uri.UnescapeDataString(request.Token);
        var Response = await userManager.ResetPasswordAsync(user, token, request.NewPassword);

        return !Response.Succeeded
            ? Response<bool>.Failure(string.Join(", ", Response.Errors.Select(e => e.Description)))
            : Response<bool>.Success(true);
    }
}