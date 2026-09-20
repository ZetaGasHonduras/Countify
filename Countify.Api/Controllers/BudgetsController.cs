using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using Countify.Api.Authorization.Policies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/budgets")]
public class BudgetsController(IUnitOfWork unitOfWork) : BaseController
{
    [HttpGet]
    [Authorize(BudgetPolicies.CanViewBudgets)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var budgets = await unitOfWork.Budgets.Query()
            .Include(b => b.Lines)
            .ThenInclude(line => line.Account)
            .OrderByDescending(b => b.FiscalYear)
            .ToListAsync(cancellationToken);

        return Ok(budgets.Select(Map));
    }

    [HttpPost]
    [Authorize(BudgetPolicies.CanCreateBudgets)]
    public async Task<IActionResult> Create([FromBody] BudgetRequest request, CancellationToken cancellationToken)
    {
        var validationError = await ValidateRequest(request, cancellationToken);
        if (validationError is not null) return BadRequest(new { error = validationError });

        var budget = new Budget { FiscalYear = request.FiscalYear, Name = request.Name.Trim() };
        var error = await ApplyLines(budget, request.Lines, cancellationToken);
        if (error is not null) return BadRequest(new { error });

        await unitOfWork.Budgets.AddAsync(budget, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Ok(new { id = budget.Id });
    }

    [HttpPut("{id:guid}")]
    [Authorize(BudgetPolicies.CanEditBudgets)]
    public async Task<IActionResult> Update(Guid id, [FromBody] BudgetRequest request, CancellationToken cancellationToken)
    {
        var budget = await unitOfWork.Budgets.Query().Include(b => b.Lines).FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        if (budget is null) return NotFound(new { error = "Presupuesto no encontrado." });

        var validationError = await ValidateRequest(request, cancellationToken, id);
        if (validationError is not null) return BadRequest(new { error = validationError });

        budget.FiscalYear = request.FiscalYear;
        budget.Name = request.Name.Trim();
        foreach (var existingLine in budget.Lines.ToList())
            await unitOfWork.BudgetLines.DeleteAsync(existingLine, cancellationToken);
        budget.Lines = [];
        var error = await ApplyLines(budget, request.Lines, cancellationToken);
        if (error is not null) return BadRequest(new { error });

        await unitOfWork.Budgets.UpdateAsync(budget, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(BudgetPolicies.CanDeleteBudgets)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var budget = await unitOfWork.Budgets.GetByIdAsync(id, cancellationToken);
        if (budget is null) return NotFound(new { error = "Presupuesto no encontrado." });
        await unitOfWork.Budgets.DeleteAsync(budget, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    private async Task<string?> ApplyLines(Budget budget, IEnumerable<BudgetLineRequest> requests, CancellationToken cancellationToken)
    {
        var lines = requests.ToList();
        if (lines.Count == 0) return "El presupuesto debe tener al menos una línea.";
        if (lines.Count > 500) return "El presupuesto no puede tener más de 500 líneas.";
        if (lines.GroupBy(l => new { l.AccountId, l.DepartmentId, l.ProjectId }).Any(g => g.Count() > 1))
            return "No se puede repetir la combinación de cuenta, departamento y proyecto.";

        foreach (var request in lines)
        {
            if (request.Months().Any(value => value < 0))
                return "Los importes de presupuesto no pueden ser negativos.";

            if (!await unitOfWork.Accounts.ExistsAsync(a => a.Id == request.AccountId, cancellationToken) ||
                !await unitOfWork.Departments.ExistsAsync(d => d.Id == request.DepartmentId, cancellationToken) ||
                !await unitOfWork.Projects.ExistsAsync(p => p.Id == request.ProjectId, cancellationToken))
                return "Una línea contiene una cuenta, departamento o proyecto inválido.";

            budget.Lines.Add(new BudgetLine
            {
                AccountId = request.AccountId,
                DepartmentId = request.DepartmentId,
                ProjectId = request.ProjectId,
                January = request.January,
                February = request.February,
                March = request.March,
                April = request.April,
                May = request.May,
                June = request.June,
                July = request.July,
                August = request.August,
                September = request.September,
                October = request.October,
                November = request.November,
                December = request.December
            });
        }
        return null;
    }

    private async Task<string?> ValidateRequest(BudgetRequest request, CancellationToken cancellationToken, Guid? currentId = null)
    {
        if (request.FiscalYear is < 2000 or > 2100) return "El año fiscal debe estar entre 2000 y 2100.";
        if (string.IsNullOrWhiteSpace(request.Name) || request.Name.Trim().Length > 200)
            return "El nombre es obligatorio y no puede superar 200 caracteres.";
        if (request.Lines is null) return "Las líneas del presupuesto son obligatorias.";

        var duplicate = await unitOfWork.Budgets.Query()
            .AnyAsync(b => b.FiscalYear == request.FiscalYear && b.Name == request.Name.Trim() && (!currentId.HasValue || b.Id != currentId.Value), cancellationToken);
        return duplicate ? "Ya existe un presupuesto con ese año y nombre." : null;
    }

    private static BudgetResponse Map(Budget budget) => new(
        budget.Id,
        budget.FiscalYear,
        budget.Name,
        budget.Lines.Select(line => new BudgetLineResponse(
            line.Id, line.AccountId, line.DepartmentId, line.ProjectId,
            line.January, line.February, line.March, line.April, line.May, line.June,
            line.July, line.August, line.September, line.October, line.November, line.December,
            line.Total)).ToList());

    public sealed class BudgetRequest
    {
        public int FiscalYear { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BudgetLineRequest> Lines { get; set; } = [];
    }

    public sealed class BudgetLineRequest
    {
        public Guid AccountId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid ProjectId { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }

        public IEnumerable<decimal> Months() => [January, February, March, April, May, June, July, August, September, October, November, December];
    }

    public sealed record BudgetResponse(Guid Id, int FiscalYear, string Name, List<BudgetLineResponse> Lines);
    public sealed record BudgetLineResponse(Guid Id, Guid AccountId, Guid DepartmentId, Guid ProjectId, decimal January, decimal February, decimal March, decimal April, decimal May, decimal June, decimal July, decimal August, decimal September, decimal October, decimal November, decimal December, decimal Total);
}
