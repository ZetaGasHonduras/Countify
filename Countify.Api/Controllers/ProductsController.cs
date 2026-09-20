using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Products.Commands.CreateProduct;
using Countify.Application.Features.Products.Commands.DeleteProduct;
using Countify.Application.Features.Products.Commands.UpdateProduct;
using Countify.Application.Features.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/products")]
public class ProductsController : BaseController
{
    [HttpGet]
    [Authorize(ProductAccountPolicies.CanViewProductAccounts)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetProductsQuery()));

    [HttpPost]
    [Authorize(ProductAccountPolicies.CanCreateProductAccounts)]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(ProductAccountPolicies.CanEditProductAccounts)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(ProductAccountPolicies.CanDeleteProductAccounts)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteProductCommand { Id = id }));
}