using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Roles.Commands.CreateRole;
using Countify.Application.Features.Roles.Commands.DeleteRole;
using Countify.Application.Features.Roles.Commands.UpdateRole;
using Countify.Application.Features.Roles.Commands.UpdateRolePermissions;
using Countify.Application.Features.Roles.Queries.GetRoleById;
using Countify.Application.Features.Roles.Queries.GetRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
public class RolesController : BaseController
{
    [HttpGet("GetAll")]
    [Authorize(RolePolicies.CanViewRoles)]
    public async Task<IActionResult> GetAll([FromQuery] GetRolesQuery query)
        => Ok(await Mediator.Send(query));

    [HttpGet("GetById/{id}")]
    [Authorize(RolePolicies.CanViewRoles)]
    public async Task<IActionResult> GetById(string id)
        => HandleResult(await Mediator.Send(new GetRoleByIdQuery { Id = id }));

    [HttpPost("Create")]
    [Authorize(RolePolicies.CanCreateRoles)]
    public async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("Update/{id}")]
    [Authorize(RolePolicies.CanEditRoles)]
    public async Task<IActionResult> Edit(string id, [FromBody] UpdateRoleCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("Delete/{id}")]
    [Authorize(RolePolicies.CanDeleteRoles)]
    public async Task<IActionResult> Delete(string id)
        => HandleResult(await Mediator.Send(new DeleteRoleCommand { Id = id }));

    [HttpPut("permissions/{id}")]
    [Authorize(RolePolicies.CanEditRoles)]
    public async Task<IActionResult> UpdatePermissions(
        string id, [FromBody] UpdateRolePermissionsCommand command)
    {
        if (id != command.RoleId)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }
}