using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Users.Commands.AssignRole;
using Countify.Application.Features.Users.Commands.ChangePassword;
using Countify.Application.Features.Users.Commands.CreateUser;
using Countify.Application.Features.Users.Commands.DeleteUser;
using Countify.Application.Features.Users.Commands.UpdateUser;
using Countify.Application.Features.Users.Queries.GetUserById;
using Countify.Application.Features.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
public class UsersController : BaseController
{
    [HttpGet("GetAll")]
    [Authorize(UserPolicies.CanViewUsers)]
    public async Task<IActionResult> GetAll([FromQuery] GetUsersQuery query)
        => Ok(await Mediator.Send(query));

    [HttpGet("GetById/{id}")]
    [Authorize(UserPolicies.CanViewUsers)]
    public async Task<IActionResult> GetById(string id)
        => HandleResult(await Mediator.Send(new GetUserByIdQuery { Id = id }));

    [HttpPost("Create")]
    [Authorize(UserPolicies.CanCreateUsers)]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("Update/{id}")]
    [Authorize(UserPolicies.CanEditUsers)]
    public async Task<IActionResult> Edit(string id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("Delete/{id}")]
    [Authorize(UserPolicies.CanDeleteUsers)]
    public async Task<IActionResult> Delete(string id)
        => HandleResult(await Mediator.Send(new DeleteUserCommand { Id = id }));

    [HttpPatch("change-password/{id}")]
    [Authorize(UserPolicies.CanEditUsers)]
    public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpPatch("assign-role{id}")]
    [Authorize(UserPolicies.CanEditUsers)]
    public async Task<IActionResult> AssignRole(string id, [FromBody] AssignRoleCommand command)
    {
        if (id != command.UserId)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }
}