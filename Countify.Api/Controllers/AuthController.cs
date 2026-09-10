using Countify.Application.Features.Auth.Commands.ForgotPassword;
using Countify.Application.Features.Auth.Commands.Login;
using Countify.Application.Features.Auth.Commands.RefreshToken;
using Countify.Application.Features.Auth.Commands.ResetPassword;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

public class AuthController : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        => HandleResult(await Mediator.Send(command));
}