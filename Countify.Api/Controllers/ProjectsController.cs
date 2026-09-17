using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Projects.Commands.CreateProject;
using Countify.Application.Features.Projects.Commands.DeleteProject;
using Countify.Application.Features.Projects.Commands.UpdateProject;
using Countify.Application.Features.Projects.Queries.GetProjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/projects")]
public class ProjectsController : BaseController
{
    [HttpGet]
    [Authorize(ProjectPolicies.CanViewProjects)]
    public async Task<IActionResult> GetAll([FromQuery] GetProjectsQuery query)
        => Ok(await Mediator.Send(query));

    [HttpPost]
    [Authorize(ProjectPolicies.CanCreateProjects)]
    public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(ProjectPolicies.CanEditProjects)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProjectCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(ProjectPolicies.CanDeleteProjects)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteProjectCommand { Id = id }));
}