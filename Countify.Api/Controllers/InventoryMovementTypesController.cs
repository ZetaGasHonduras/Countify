using Countify.Api.Authorization.Policies;
using Countify.Application.Features.InventoryMovementTypes.Commands.CreateInventoryMovementType;
using Countify.Application.Features.InventoryMovementTypes.Commands.DeleteInventoryMovementType;
using Countify.Application.Features.InventoryMovementTypes.Commands.UpdateInventoryMovementType;
using Countify.Application.Features.InventoryMovementTypes.Queries.GetInventoryMovementTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/inventory-movement-types")]
public class InventoryMovementTypesController : BaseController
{
    [HttpGet]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovementTypes)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetInventoryMovementTypesQuery()));

    [HttpPost]
    [Authorize(InventoryCatalogPolicies.CanCreateInventoryMovementTypes)]
    public async Task<IActionResult> Create([FromBody] CreateInventoryMovementTypeCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(InventoryCatalogPolicies.CanEditInventoryMovementTypes)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInventoryMovementTypeCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(InventoryCatalogPolicies.CanDeleteInventoryMovementTypes)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteInventoryMovementTypeCommand { Id = id }));
}
