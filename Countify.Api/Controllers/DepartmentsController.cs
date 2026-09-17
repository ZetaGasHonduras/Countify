using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Departments.Commands.CreateDepartment;
using Countify.Application.Features.Departments.Commands.DeleteDepartment;
using Countify.Application.Features.Departments.Commands.UpdateDepartment;
using Countify.Application.Features.Departments.Queries.GetDepartments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/departments")]
public class DepartmentsController : BaseController
{
    [HttpGet]
    [Authorize(DepartmentPolicies.CanViewDepartments)]
    public async Task<IActionResult> GetAll([FromQuery] GetDepartmentsQuery query)
        => Ok(await Mediator.Send(query));

    [HttpPost]
    [Authorize(DepartmentPolicies.CanCreateDepartments)]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(DepartmentPolicies.CanEditDepartments)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDepartmentCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(DepartmentPolicies.CanDeleteDepartments)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteDepartmentCommand { Id = id }));
}