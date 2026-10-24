using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Configurations.Queries.GetCompanySettings;
using Countify.Application.Features.InventoryMovements.Commands.CreateInventoryMovement;
using Countify.Application.Features.InventoryMovements.Commands.DeleteInventoryMovement;
using Countify.Application.Features.InventoryMovements.Commands.UpdateInventoryMovement;
using Countify.Application.Features.InventoryMovements.Commands.VoidInventoryMovement;
using Countify.Application.Features.InventoryMovements.Queries.GetInventoryMovementById;
using Countify.Application.Features.InventoryMovements.Queries.GetInventoryMovements;
using Countify.Application.Features.InventoryMovements.Queries.GetInventoryStock;
using Countify.Application.Features.InventoryMovements.Queries.GetPendingInventoryRequests;
using Countify.Infrastructure.TemplateBuilder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/inventory-movements")]
public class InventoryMovementsController : BaseController
{
    [HttpGet]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovements)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetInventoryMovementsQuery()));

    [HttpGet("{id:guid}")]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovements)]
    public async Task<IActionResult> GetById(Guid id)
        => HandleResult(await Mediator.Send(new GetInventoryMovementByIdQuery { Id = id }));

    /// <summary>Existencias derivadas por producto × ubicación (VSTExistenciasUbicaciones del legacy).</summary>
    [HttpGet("stock")]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovements)]
    public async Task<IActionResult> GetStock(
        [FromQuery] Guid? warehouseId, [FromQuery] Guid? locationId, [FromQuery] Guid? productId)
        => HandleResult(await Mediator.Send(new GetInventoryStockQuery
        {
            WarehouseId = warehouseId,
            LocationId = locationId,
            ProductId = productId,
        }));

    [HttpGet("stock/export")]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovements)]
    public async Task<IActionResult> ExportStock(
        [FromQuery] Guid? warehouseId, [FromQuery] Guid? locationId, [FromQuery] Guid? productId)
    {
        var result = await Mediator.Send(new GetInventoryStockQuery
        {
            WarehouseId = warehouseId,
            LocationId = locationId,
            ProductId = productId,
        });
        if (!result.IsSuccess || result.Data is null) return HandleResult(result);

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("ProductoCodigo,Producto,Almacen,UbicacionCodigo,Ubicacion,Entradas,Salidas,Existencia");
        foreach (var s in result.Data)
        {
            sb.AppendLine($"{s.ProductCode},\"{s.ProductName}\",\"{s.WarehouseName}\",{s.LocationCode},\"{s.LocationName}\"," +
                          $"{s.Inbound:0.###},{s.Outbound:0.###},{s.OnHand:0.###}");
        }

        return File(System.Text.Encoding.UTF8.GetBytes(sb.ToString()), "text/csv",
            $"existencias-{DateTime.UtcNow:yyyyMMdd-HHmm}.csv");
    }

    [HttpGet("stock/export/pdf")]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovements)]
    public async Task<IActionResult> ExportStockPdf(
        [FromQuery] Guid? warehouseId, [FromQuery] Guid? locationId, [FromQuery] Guid? productId)
    {
        var result = await Mediator.Send(new GetInventoryStockQuery
        {
            WarehouseId = warehouseId,
            LocationId = locationId,
            ProductId = productId,
        });
        if (!result.IsSuccess || result.Data is null) return HandleResult(result);

        var settings = await Mediator.Send(new GetCompanySettingsQuery());
        return File(InventoryStockPdfBuilder.Build(result.Data, "Reporte de existencias", settings.Data), "application/pdf",
            $"existencias-{DateTime.UtcNow:yyyyMMdd-HHmm}.pdf");
    }

    /// <summary>Solicitudes TP− vigentes sin consumir (selector del ajuste negativo).</summary>
    [HttpGet("pending-requests")]
    [Authorize(InventoryCatalogPolicies.CanViewInventoryMovements)]
    public async Task<IActionResult> GetPendingRequests()
        => HandleResult(await Mediator.Send(new GetPendingInventoryRequestsQuery()));

    [HttpPost]
    [Authorize(InventoryCatalogPolicies.CanCreateInventoryMovements)]
    public async Task<IActionResult> Create([FromBody] CreateInventoryMovementCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(InventoryCatalogPolicies.CanEditInventoryMovements)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInventoryMovementCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpPost("{id:guid}/void")]
    [Authorize(InventoryCatalogPolicies.CanVoidInventoryMovements)]
    public async Task<IActionResult> Void(Guid id, [FromBody] VoidInventoryMovementCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    /// <summary>Solo solicitudes TP− sin consumir (paridad legacy: lo demás se anula, no se borra).</summary>
    [HttpDelete("{id:guid}")]
    [Authorize(InventoryCatalogPolicies.CanEditInventoryMovements)]
    public async Task<IActionResult> Delete(Guid id)
        => HandleResult(await Mediator.Send(new DeleteInventoryMovementCommand { Id = id }));
}
