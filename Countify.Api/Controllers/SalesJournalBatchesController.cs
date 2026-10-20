using Countify.Api.Authorization.Policies;
using Countify.Application.Features.SalesJournalBatches.Commands.CreateSalesJournalBatch;
using Countify.Application.Features.SalesJournalBatches.Queries.GetSalesJournalBatches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/sales-journal-batches")]
public class SalesJournalBatchesController : BaseController
{
    [HttpGet]
    [Authorize(SalesJournalBatchPolicies.CanViewSalesJournalBatches)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetSalesJournalBatchesQuery()));

    /// <summary>Legacy CntPartidaDeVentasVC: agrega las facturas del rango en una partida.</summary>
    [HttpPost]
    [Authorize(SalesJournalBatchPolicies.CanCreateSalesJournalBatches)]
    public async Task<IActionResult> Create([FromBody] CreateSalesJournalBatchCommand command)
        => HandleResult(await Mediator.Send(command));
}
