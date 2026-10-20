using Countify.Api.Authorization.Policies;
using Countify.Application.Features.PayableConcepts.Commands.CreatePayableConcept;
using Countify.Application.Features.PayableConcepts.Commands.DeletePayableConcept;
using Countify.Application.Features.PayableConcepts.Commands.UpdatePayableConcept;
using Countify.Application.Features.PayableConcepts.Queries.GetPayableConcepts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/payable-concepts")]
public class PayableConceptsController : BaseController
{
    [HttpGet]
    [Authorize(PayableConceptPolicies.CanViewPayableConcepts)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetPayableConceptsQuery()));

    [HttpPost]
    [Authorize(PayableConceptPolicies.CanCreatePayableConcepts)]
    public async Task<IActionResult> Create([FromBody] CreatePayableConceptCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(PayableConceptPolicies.CanEditPayableConcepts)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePayableConceptCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(PayableConceptPolicies.CanDeletePayableConcepts)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeletePayableConceptCommand { Id = id }));
}
