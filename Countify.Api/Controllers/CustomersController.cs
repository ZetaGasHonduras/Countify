using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Customers.Commands.CreateCustomer;
using Countify.Application.Features.Customers.Commands.DeleteCustomer;
using Countify.Application.Features.Customers.Commands.UpdateCustomer;
using Countify.Application.Features.Customers.Queries.GetCustomers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/customers")]
public class CustomersController : BaseController
{
    [HttpGet]
    [Authorize(CustomerPolicies.CanViewCustomers)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetCustomersQuery()));

    [HttpPost]
    [Authorize(CustomerPolicies.CanCreateCustomers)]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(CustomerPolicies.CanEditCustomers)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(CustomerPolicies.CanDeleteCustomers)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteCustomerCommand { Id = id }));
}