using Countify.Api.Authorization.Policies;
using Countify.Application.Features.CashRegisters.Commands.CreateCashRegister;
using Countify.Application.Features.CashRegisters.Commands.DeleteCashRegister;
using Countify.Application.Features.CashRegisters.Commands.UpdateCashRegister;
using Countify.Application.Features.CashRegisters.Queries.GetCashRegisters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/cash-registers")]
public class CashRegistersController : BaseController
{
    [HttpGet]
    [Authorize(PosCatalogPolicies.CanViewCashRegisters)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetCashRegistersQuery()));

    [HttpPost]
    [Authorize(PosCatalogPolicies.CanCreateCashRegisters)]
    public async Task<IActionResult> Create([FromBody] CreateCashRegisterCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(PosCatalogPolicies.CanEditCashRegisters)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCashRegisterCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(PosCatalogPolicies.CanDeleteCashRegisters)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteCashRegisterCommand { Id = id }));
}
