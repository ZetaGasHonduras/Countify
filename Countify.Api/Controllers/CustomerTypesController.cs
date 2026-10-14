using Countify.Api.Authorization.Policies;
using Countify.Application.Features.CustomerTypes.Commands.CreateCustomerType;
using Countify.Application.Features.CustomerTypes.Commands.DeleteCustomerType;
using Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType;
using Countify.Application.Features.CustomerTypes.Queries.GetCustomerTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/customer-types")]
public class CustomerTypesController : BaseController
{
    [HttpGet]
    [Authorize(CustomerTypePolicies.CanViewCustomerTypes)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetCustomerTypesQuery()));

    [HttpPost]
    [Authorize(CustomerTypePolicies.CanCreateCustomerTypes)]
    public async Task<IActionResult> Create([FromBody] CreateCustomerTypeCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(CustomerTypePolicies.CanEditCustomerTypes)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerTypeCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(CustomerTypePolicies.CanDeleteCustomerTypes)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteCustomerTypeCommand { Id = id }));
}