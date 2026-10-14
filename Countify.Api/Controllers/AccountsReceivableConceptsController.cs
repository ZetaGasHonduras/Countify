using Countify.Api.Authorization.Policies;
using Countify.Application.Features.AccountsReceivableConcepts.Commands.CreateAccountsReceivableConcept;
using Countify.Application.Features.AccountsReceivableConcepts.Commands.DeleteAccountsReceivableConcept;
using Countify.Application.Features.AccountsReceivableConcepts.Commands.UpdateAccountsReceivableConcept;
using Countify.Application.Features.AccountsReceivableConcepts.Queries.GetAccountsReceivableConcepts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/accounts-receivable-concepts")]
public class AccountsReceivableConceptsController : BaseController
{
    [HttpGet]
    [Authorize(AccountsReceivableConceptPolicies.CanViewAccountsReceivableConcepts)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetAccountsReceivableConceptsQuery()));

    [HttpPost]
    [Authorize(AccountsReceivableConceptPolicies.CanCreateAccountsReceivableConcepts)]
    public async Task<IActionResult> Create([FromBody] CreateAccountsReceivableConceptCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(AccountsReceivableConceptPolicies.CanEditAccountsReceivableConcepts)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAccountsReceivableConceptCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(AccountsReceivableConceptPolicies.CanDeleteAccountsReceivableConcepts)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteAccountsReceivableConceptCommand { Id = id }));
}