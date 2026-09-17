using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Projects.Commands.CreateProjectGroup;
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
}