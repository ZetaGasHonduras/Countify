using Countify.Api.Authorization.Policies;
using Countify.Application.Features.AccountingPeriods.Commands.CloseAccountingPeriod;
using Countify.Application.Features.AccountingPeriods.Commands.CreateAccountingPeriod;
using Countify.Application.Features.AccountingPeriods.Commands.DeleteAccountingPeriod;
using Countify.Application.Features.AccountingPeriods.Queries.GetAccountingPeriods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/accounting-periods")]
public class AccountingPeriodsController : BaseController
{
    [HttpGet]
    [Authorize(AccountingPeriodPolicies.CanViewAccountingPeriods)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetAccountingPeriodsQuery()));

    [HttpPost]
    [Authorize(AccountingPeriodPolicies.CanCreateAccountingPeriods)]
    public async Task<IActionResult> Create([FromBody] CreateAccountingPeriodCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPost("{id:guid}/close")]
    [Authorize(AccountingPeriodPolicies.CanCloseAccountingPeriods)]
    public async Task<IActionResult> Close(Guid id)
        => HandleResult(await Mediator.Send(new CloseAccountingPeriodCommand { Id = id }));

    [HttpDelete("{id:guid}")]
    [Authorize(AccountingPeriodPolicies.CanDeleteAccountingPeriods)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteAccountingPeriodCommand { Id = id }));
}