using Countify.Api.Authorization.Policies;
using Countify.Application.Features.InventoryMovements.Commands.CreateInventoryMovement;
using Countify.Application.Features.InventoryMovements.Commands.DeleteInventoryMovement;
using Countify.Application.Features.InventoryMovements.Commands.UpdateInventoryMovement;
using Countify.Application.Features.InventoryMovements.Commands.VoidInventoryMovement;
using Countify.Application.Features.InventoryMovements.Queries.GetInventoryMovementById;
using Countify.Application.Features.InventoryMovements.Queries.GetInventoryMovements;
using Countify.Application.Features.InventoryMovements.Queries.GetInventoryStock;
using Countify.Application.Features.InventoryMovements.Queries.GetPendingInventoryRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/inventory-movements")]
public class InventoryMovementsController : BaseController
{
    [HttpGet]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovements)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetInventoryMovementsQuery()));

    [HttpGet("{id:guid}")]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovements)]
    public async Task<IActionResult> GetById(Guid id)
        => HandleResult(await Mediator.Send(new GetInventoryMovementByIdQuery { Id = id }));

    /// <summary>Existencias derivadas por producto × ubicación (VSTExistenciasUbicaciones del legacy).</summary>
    [HttpGet("stock")]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovements)]
    public async Task<IActionResult> GetStock(
        [FromQuery] Guid? warehouseId, [FromQuery] Guid? locationId, [FromQuery] Guid? productId)
        => HandleResult(await Mediator.Send(new GetInventoryStockQuery
        {
            WarehouseId = warehouseId,
            LocationId = locationId,
            ProductId = productId,
        }));

    /// <summary>Solicitudes TP− vigentes sin consumir (selector del ajuste negativo).</summary>
    [HttpGet("pending-requests")]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovements)]
    public async Task<IActionResult> GetPendingRequests()
        => HandleResult(await Mediator.Send(new GetPendingInventoryRequestsQuery()));

    [HttpPost]
    [Authorize(InventoryCatalogPolicies.CanCreateInventoryMovements)]
    public async Task<IActionResult> Create([FromBody] CreateInventoryMovementCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(InventoryCatalogPolicies.CanEditInventoryMovements)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInventoryMovementCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpPost("{id:guid}/void")]
    [Authorize(InventoryCatalogPolicies.CanVoidInventoryMovements)]
    public async Task<IActionResult> Void(Guid id, [FromBody] VoidInventoryMovementCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    /// <summary>Solo solicitudes TP− sin consumir (paridad legacy: lo demás se anula, no se borra).</summary>
    [HttpDelete("{id:guid}")]
    [Authorize(InventoryCatalogPolicies.CanEditInventoryMovements)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteInventoryMovementCommand { Id = id }));
}
