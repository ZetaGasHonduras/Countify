using Countify.Api.Authorization.Policies;
using Countify.Application.Features.PaymentMethods.Commands.CreatePaymentMethod;
using Countify.Application.Features.PaymentMethods.Commands.DeletePaymentMethod;
using Countify.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod;
using Countify.Application.Features.PaymentMethods.Queries.GetPaymentMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/payment-methods")]
public class PaymentMethodsController : BaseController
{
    [HttpGet]
    [Authorize(PaymentMethodPolicies.CanViewPaymentMethods)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetPaymentMethodsQuery()));

    [HttpPost]
    [Authorize(PaymentMethodPolicies.CanCreatePaymentMethods)]
    public async Task<IActionResult> Create([FromBody] CreatePaymentMethodCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(PaymentMethodPolicies.CanEditPaymentMethods)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePaymentMethodCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(PaymentMethodPolicies.CanDeletePaymentMethods)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeletePaymentMethodCommand { Id = id }));
}
