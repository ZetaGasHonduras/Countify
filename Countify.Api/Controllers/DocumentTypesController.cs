using Countify.Api.Authorization.Policies;
using Countify.Application.Features.DocumentTypes.Commands.CreateDocumentType;
using Countify.Application.Features.DocumentTypes.Commands.DeleteDocumentType;
using Countify.Application.Features.DocumentTypes.Commands.UpdateDocumentType;
using Countify.Application.Features.DocumentTypes.Queries.GetDocumentTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/document-types")]
public class DocumentTypesController : BaseController
{
    [HttpGet]
    [Authorize(DocumentTypePolicies.CanViewDocumentTypes)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetDocumentTypesQuery()));

    [HttpPost]
    [Authorize(DocumentTypePolicies.CanCreateDocumentTypes)]
    public async Task<IActionResult> Create([FromBody] CreateDocumentTypeCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(DocumentTypePolicies.CanEditDocumentTypes)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDocumentTypeCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(DocumentTypePolicies.CanDeleteDocumentTypes)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteDocumentTypeCommand { Id = id }));
}