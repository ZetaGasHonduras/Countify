using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Reports.Queries.GetTrialBalance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/reports")]
public class ReportsController : BaseController
{
    [HttpGet("trial-balance")]
    [Authorize(ReportsPolicies.CanViewReports)]
    public async Task<IActionResult> GetTrialBalance([FromQuery] GetTrialBalanceQuery query)
        => HandleResult(await Mediator.Send(query));
}
