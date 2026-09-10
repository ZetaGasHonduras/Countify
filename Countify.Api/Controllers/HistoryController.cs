using Countify.Api.Authorization.Policies;
using Countify.Application.Features.History.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
public class HistoryController(IMediator mediator) : BaseController
{
    [HttpGet("GetHistory")]
    [Authorize(HistoryPolicies.CanViewHistorie)]
    public async Task<IActionResult> GetByEntity([FromQuery] GetEntityHistoryQuery query)
    {
        var result = await mediator.Send(query);

        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}