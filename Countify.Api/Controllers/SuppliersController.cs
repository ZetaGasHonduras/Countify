using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Suppliers.Commands.CreateSupplier;
using Countify.Application.Features.Suppliers.Commands.DeleteSupplier;
using Countify.Application.Features.Suppliers.Commands.UpdateSupplier;
using Countify.Application.Features.Suppliers.Queries.GetSuppliers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/suppliers")]
public class SuppliersController : BaseController
{
    [HttpGet]
    [Authorize(SupplierPolicies.CanViewSuppliers)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetSuppliersQuery()));

    [HttpPost]
    [Authorize(SupplierPolicies.CanCreateSuppliers)]
    public async Task<IActionResult> Create([FromBody] CreateSupplierCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(SupplierPolicies.CanEditSuppliers)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSupplierCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(SupplierPolicies.CanDeleteSuppliers)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteSupplierCommand { Id = id }));
}
