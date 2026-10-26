using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Cashiers.Commands.CreateCashier;
using Countify.Application.Features.Cashiers.Commands.DeleteCashier;
using Countify.Application.Features.Cashiers.Commands.UpdateCashier;
using Countify.Application.Features.Cashiers.Queries.GetCashiers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/cashiers")]
public class CashiersController : BaseController
{
    [HttpGet]
    [Authorize(PosCatalogPolicies.CanViewCashiers)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetCashiersQuery()));

    [HttpPost]
    [Authorize(PosCatalogPolicies.CanCreateCashiers)]
    public async Task<IActionResult> Create([FromBody] CreateCashierCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(PosCatalogPolicies.CanEditCashiers)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCashierCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(PosCatalogPolicies.CanDeleteCashiers)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteCashierCommand { Id = id }));
}
