using Countify.Api.Authorization.Policies;
using Countify.Application.Features.SupplierTypes.Commands.CreateSupplierType;
using Countify.Application.Features.SupplierTypes.Commands.DeleteSupplierType;
using Countify.Application.Features.SupplierTypes.Commands.UpdateSupplierType;
using Countify.Application.Features.SupplierTypes.Queries.GetSupplierTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/supplier-types")]
public class SupplierTypesController : BaseController
{
    [HttpGet]
    [Authorize(SupplierTypePolicies.CanViewSupplierTypes)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetSupplierTypesQuery()));

    [HttpPost]
    [Authorize(SupplierTypePolicies.CanCreateSupplierTypes)]
    public async Task<IActionResult> Create([FromBody] CreateSupplierTypeCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(SupplierTypePolicies.CanEditSupplierTypes)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSupplierTypeCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(SupplierTypePolicies.CanDeleteSupplierTypes)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteSupplierTypeCommand { Id = id }));
}
