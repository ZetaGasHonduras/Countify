using Countify.Api.Authorization.Policies;
using Countify.Application.Features.JournalEntries.Commands.ApproveJournalEntry;
using Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry;
using Countify.Application.Features.JournalEntries.Commands.DeleteJournalEntry;
using Countify.Application.Features.JournalEntries.Commands.PostJournalEntry;
using Countify.Application.Features.JournalEntries.Commands.UpdateJournalEntry;
using Countify.Application.Features.JournalEntries.Commands.VoidJournalEntry;
using Countify.Application.Features.JournalEntries.Queries.GetAccountMovements;
using Countify.Application.Features.JournalEntries.Queries.GetJournalEntries;
using Countify.Application.Features.JournalEntries.Queries.GetJournalEntryById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/journal-entries")]
public class JournalEntriesController : BaseController
{
    [HttpGet]
    [Authorize(JournalEntryPolicies.CanViewJournalEntries)]
    public async Task<IActionResult> GetAll([FromQuery] GetJournalEntriesQuery query)
        => Ok(await Mediator.Send(query));

    [HttpGet("{id:guid}")]
    [Authorize(JournalEntryPolicies.CanViewJournalEntries)]
    public async Task<IActionResult> GetById(Guid id)
        => HandleResult(await Mediator.Send(new GetJournalEntryByIdQuery { Id = id }));

    [HttpGet("account-movements")]
    [Authorize(JournalEntryPolicies.CanViewJournalEntries)]
    public async Task<IActionResult> GetAccountMovements([FromQuery] GetAccountMovementsQuery query)
        => HandleResult(await Mediator.Send(query));

    [HttpPost]
    [Authorize(JournalEntryPolicies.CanCreateJournalEntries)]
    public async Task<IActionResult> Create([FromBody] CreateJournalEntryCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(JournalEntryPolicies.CanEditJournalEntries)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateJournalEntryCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(JournalEntryPolicies.CanDeleteJournalEntries)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteJournalEntryCommand { Id = id }));

    [HttpPost("{id:guid}/approve")]
    [Authorize(JournalEntryPolicies.CanApproveJournalEntries)]
    public async Task<IActionResult> Approve(Guid id)
        => HandleResult(await Mediator.Send(new ApproveJournalEntryCommand { Id = id }));

    [HttpPost("{id:guid}/post")]
    [Authorize(JournalEntryPolicies.CanPostJournalEntries)]
    public async Task<IActionResult> Post(Guid id)
        => HandleResult(await Mediator.Send(new PostJournalEntryCommand { Id = id }));

    [HttpPost("{id:guid}/void")]
    [Authorize(JournalEntryPolicies.CanVoidJournalEntries)]
    public async Task<IActionResult> Void(Guid id)
        => HandleResult(await Mediator.Send(new VoidJournalEntryCommand { Id = id }));
}