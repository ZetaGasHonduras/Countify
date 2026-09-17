using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Accounts.Commands.CreateAccount;
using Countify.Application.Features.Accounts.Commands.DeleteAccount;
using Countify.Application.Features.Accounts.Commands.UpdateAccount;
using Countify.Application.Features.Accounts.Queries.GetAccountById;
using Countify.Application.Features.Accounts.Queries.GetAccounts;
using Countify.Application.Features.JournalEntries.Queries.GetAccountMovements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/accounts")]
public class AccountsController : BaseController
{
    [HttpGet]
    [Authorize(AccountPolicies.CanViewAccounts)]
    public async Task<IActionResult> GetAll([FromQuery] GetAccountsQuery query)
        => Ok(await Mediator.Send(query));

    [HttpGet("{id:guid}")]
    [Authorize(AccountPolicies.CanViewAccounts)]
    public async Task<IActionResult> GetById(Guid id)
        => HandleResult(await Mediator.Send(new GetAccountByIdQuery { Id = id }));

    [HttpGet("{id:guid}/movements")]
    [Authorize(AccountPolicies.CanViewAccounts)]
    public async Task<IActionResult> GetMovements(Guid id)
        => HandleResult(await Mediator.Send(new GetAccountMovementsQuery { AccountId = id }));

    [HttpPost]
    [Authorize(AccountPolicies.CanCreateAccounts)]
    public async Task<IActionResult> Create([FromBody] CreateAccountCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(AccountPolicies.CanEditAccounts)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAccountCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(AccountPolicies.CanDeleteAccounts)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteAccountCommand { Id = id }));
}