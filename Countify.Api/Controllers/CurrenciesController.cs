using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Currencies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/currencies")]
public class CurrenciesController : BaseController
{
    [HttpGet, Authorize(CurrencyPolicies.View)] public async Task<IActionResult> GetAll() => HandleResult(await Mediator.Send(new GetCurrenciesQuery()));
    [HttpPost, Authorize(CurrencyPolicies.Create)] public async Task<IActionResult> Create(CreateCurrencyCommand command) => HandleResult(await Mediator.Send(command));
    [HttpPut("{id:guid}"), Authorize(CurrencyPolicies.Edit)] public async Task<IActionResult> Update(Guid id, UpdateCurrencyCommand command) => id != command.Id ? BadRequest() : HandleResult(await Mediator.Send(command));
    [HttpDelete("{id:guid}"), Authorize(CurrencyPolicies.Delete)] public async Task<IActionResult> Delete(Guid id) => HandleResult(await Mediator.Send(new DeleteCurrencyCommand(id)));
}
