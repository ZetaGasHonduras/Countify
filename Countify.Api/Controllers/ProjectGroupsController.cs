using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Projects.Commands.CreateProjectGroup;
using Countify.Application.Features.Projects.Commands.DeleteProjectGroup;
using Countify.Application.Features.Projects.Commands.UpdateProjectGroup;
using Countify.Application.Features.Projects.Queries.GetProjectGroups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/project-groups")]
public class ProjectGroupsController : BaseController
{
    [HttpGet]
    [Authorize(ProjectGroupPolicies.CanViewProjectGroups)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetProjectGroupsQuery()));

    [HttpPost]
    [Authorize(ProjectGroupPolicies.CanCreateProjectGroups)]
    public async Task<IActionResult> Create([FromBody] CreateProjectGroupCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(ProjectGroupPolicies.CanEditProjectGroups)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProjectGroupCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(ProjectGroupPolicies.CanDeleteProjectGroups)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteProjectGroupCommand { Id = id }));
}