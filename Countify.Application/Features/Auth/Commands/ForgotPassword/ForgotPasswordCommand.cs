using Countify.Application.Common.Interfaces;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Auth.Commands.ForgotPassword;

public record ForgotPasswordCommand(string Email) : IRequest<Response<bool>>;

public class ForgotPasswordCommandHandler(
    UserManager<ApplicationUser> userManager,
    IEmailService emailService)
    : IRequestHandler<ForgotPasswordCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        // Siempre respondemos true para no revelar si el email existe
        if (user is null || !user.IsActive)
            return Response<bool>.Success(true);

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var encoded = Uri.EscapeDataString(token);

        await emailService.SendPasswordResetAsync(user.Email!, user.FirstName, encoded);

        return Response<bool>.Success(true);
    }
}