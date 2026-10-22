using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Warehouses.Commands.CreateWarehouse;
using Countify.Application.Features.Warehouses.Commands.DeleteWarehouse;
using Countify.Application.Features.Warehouses.Commands.UpdateWarehouse;
using Countify.Application.Features.Warehouses.Queries.GetWarehouses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/warehouses")]
public class WarehousesController : BaseController
{
    [HttpGet]
    [Authorize(InventoryCatalogPolicies.CanViewWarehouses)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetWarehousesQuery()));

    [HttpPost]
    [Authorize(InventoryCatalogPolicies.CanCreateWarehouses)]
    public async Task<IActionResult> Create([FromBody] CreateWarehouseCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(InventoryCatalogPolicies.CanEditWarehouses)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWarehouseCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(InventoryCatalogPolicies.CanDeleteWarehouses)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteWarehouseCommand { Id = id }));
}
