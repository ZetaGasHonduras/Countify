using Countify.Api.Authorization.Policies;
using Countify.Application.Features.ProductAccounts.Commands.CreateProductAccount;
using Countify.Application.Features.ProductAccounts.Commands.DeleteProductAccount;
using Countify.Application.Features.ProductAccounts.Commands.UpdateProductAccount;
using Countify.Application.Features.ProductAccounts.Queries.GetProductAccounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/product-accounts")]
public class ProductAccountsController : BaseController
{
    [HttpGet]
    [Authorize(ProductAccountPolicies.CanViewProductAccounts)]
    public async Task<IActionResult> GetAll([FromQuery] GetProductAccountsQuery query)
        => Ok(await Mediator.Send(query));

    [HttpPost]
    [Authorize(ProductAccountPolicies.CanCreateProductAccounts)]
    public async Task<IActionResult> Create([FromBody] CreateProductAccountCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(ProductAccountPolicies.CanEditProductAccounts)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductAccountCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(ProductAccountPolicies.CanDeleteProductAccounts)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteProductAccountCommand { Id = id }));
}