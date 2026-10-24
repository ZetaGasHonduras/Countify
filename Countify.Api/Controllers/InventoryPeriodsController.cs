using Countify.Api.Authorization.Policies;
using Countify.Application.Features.InventoryPeriods.Commands.CloseInventoryPeriod;
using Countify.Application.Features.InventoryPeriods.Commands.CreateInventoryPeriod;
using Countify.Application.Features.InventoryPeriods.Commands.ReopenInventoryPeriod;
using Countify.Application.Features.InventoryPeriods.Queries.GetInventoryPeriodCosts;
using Countify.Application.Features.InventoryPeriods.Queries.GetInventoryPeriods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/inventory-periods")]
public class InventoryPeriodsController : BaseController
{
    [HttpGet]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryPeriods)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetInventoryPeriodsQuery()));

    [HttpGet("{id:guid}/costs")]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryPeriods)]
    public async Task<IActionResult> GetCosts(Guid id)
        => HandleResult(await Mediator.Send(new GetInventoryPeriodCostsQuery { PeriodId = id }));

    [HttpPost]
    [Authorize(InventoryCatalogPolicies.CanManageInventoryPeriods)]
    public async Task<IActionResult> Create([FromBody] CreateInventoryPeriodCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPost("{id:guid}/close")]
    [Authorize(InventoryCatalogPolicies.CanManageInventoryPeriods)]
    public async Task<IActionResult> Close(Guid id)
        => HandleResult(await Mediator.Send(new CloseInventoryPeriodCommand { Id = id }));

    [HttpPost("{id:guid}/reopen")]
    [Authorize(InventoryCatalogPolicies.CanManageInventoryPeriods)]
    public async Task<IActionResult> Reopen(Guid id)
        => HandleResult(await Mediator.Send(new ReopenInventoryPeriodCommand { Id = id }));
}
