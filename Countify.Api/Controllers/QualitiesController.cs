using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Qualities.Commands.CreateQuality;
using Countify.Application.Features.Qualities.Commands.DeleteQuality;
using Countify.Application.Features.Qualities.Commands.UpdateQuality;
using Countify.Application.Features.Qualities.Queries.GetQualities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/qualities")]
public class QualitiesController : BaseController
{
    [HttpGet]
    [Authorize(ProductAccountPolicies.CanViewProductAccounts)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetQualitiesQuery()));

    [HttpPost]
    [Authorize(ProductAccountPolicies.CanCreateProductAccounts)]
    public async Task<IActionResult> Create([FromBody] CreateQualityCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(ProductAccountPolicies.CanEditProductAccounts)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateQualityCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(ProductAccountPolicies.CanDeleteProductAccounts)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteQualityCommand { Id = id }));
}