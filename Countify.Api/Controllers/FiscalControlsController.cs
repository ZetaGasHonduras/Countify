using Countify.Api.Authorization.Policies;
using Countify.Application.Features.FiscalControls.Commands.CreateFiscalControl;
using Countify.Application.Features.FiscalControls.Commands.DeleteFiscalControl;
using Countify.Application.Features.FiscalControls.Commands.UpdateFiscalControl;
using Countify.Application.Features.FiscalControls.Queries.GetFiscalControls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/fiscal-controls")]
public class FiscalControlsController : BaseController
{
    [HttpGet]
    [Authorize(FiscalControlPolicies.CanViewFiscalControls)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetFiscalControlsQuery()));

    [HttpPost]
    [Authorize(FiscalControlPolicies.CanCreateFiscalControls)]
    public async Task<IActionResult> Create([FromBody] CreateFiscalControlCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(FiscalControlPolicies.CanEditFiscalControls)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFiscalControlCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(FiscalControlPolicies.CanDeleteFiscalControls)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteFiscalControlCommand { Id = id }));
}
