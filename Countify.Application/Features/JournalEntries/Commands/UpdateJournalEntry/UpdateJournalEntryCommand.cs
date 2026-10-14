using AutoMapper;
using Countify.Application.Features.AccountsReceivableDocuments;
using Countify.Application.Features.JournalEntries.DTOs;
using Countify.Application.Features.JournalEntries;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.JournalEntries.Commands.UpdateJournalEntry;

public class UpdateJournalEntryCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public Guid TypeId { get; set; }
    public Guid? PeriodId { get; set; }
    public DateTime ReferenceDate { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string Concept { get; set; } = string.Empty;
    public string? Observations { get; set; }
    public string? Code { get; set; }
    public List<JournalEntryLineRequest> Lines { get; set; } = [];
}

public class UpdateJournalEntryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateJournalEntryCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateJournalEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await unitOfWork.JournalEntries.Query()
            .Include(e => e.Lines)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (entry is null)
            return Response<bool>.NotFound($"Partida {request.Id} no encontrada.");

        if (entry.Status == JournalEntryStatus.Voided)
            return Response<bool>.Failure("No se pueden editar partidas anuladas.");

        if (entry.PeriodId is not null)
        {
            var currentPeriod = await unitOfWork.AccountingPeriods.GetByIdAsync(
                entry.PeriodId.Value, cancellationToken);

            if (currentPeriod?.IsClosed == true)
                return Response<bool>.Failure("El período de la partida está cerrado; no se puede editar.");
        }

        var type = await unitOfWork.DocumentTypes.GetByIdAsync(request.TypeId, cancellationToken);
        if (type is null)
            return Response<bool>.NotFound($"Tipo de documento {request.TypeId} no encontrado.");

        var period = await unitOfWork.AccountingPeriods.Query()
            .Where(p => p.Month.Month == request.ReferenceDate.Month
                     && p.Month.Year == request.ReferenceDate.Year)
            .FirstOrDefaultAsync(cancellationToken);

        if (period is not null && period.IsClosed)
            return Response<bool>.Failure($"El período {period.Month:yyyy-MM} está cerrado; no se pueden editar partidas.");

        var settings = await unitOfWork.CompanySettings.Query()
            .FirstOrDefaultAsync(cancellationToken);

        if (settings is null)
            return Response<bool>.Failure("No hay configuración de la empresa.");

        var ruleError = JournalEntryRules.Validate(true, request.Lines, settings);
        if (ruleError is not null)
            return Response<bool>.Failure(ruleError);

        var budgetError = await BudgetAvailabilityValidator.ValidateAsync(
            unitOfWork, request.Lines, request.ReferenceDate, request.Id, cancellationToken);
        if (budgetError is not null)
            return Response<bool>.Failure(budgetError);

        var accountIds = request.Lines.Select(l => l.AccountId).Distinct().ToList();
        var accounts = await unitOfWork.Accounts.Query()
            .Where(a => accountIds.Contains(a.Id))
            .ToDictionaryAsync(a => a.Id, cancellationToken);

        if (accounts.Count != accountIds.Count)
            return Response<bool>.Failure("Hay cuentas contables inválidas en las líneas.");

        var auxError = await JournalEntryAuxValidator.ValidateAsync(
            unitOfWork, request.Lines, accounts, cancellationToken);
        if (auxError is not null)
            return Response<bool>.Failure(auxError);

        var departmentIds = request.Lines
            .Where(l => l.DepartmentId.HasValue)
            .Select(l => l.DepartmentId!.Value)
            .Distinct()
            .ToList();

        if (departmentIds.Count > 0)
        {
            var existingDepartments = await unitOfWork.Departments.CountAsync(
                unitOfWork.Departments.Query().Where(d => departmentIds.Contains(d.Id)),
                cancellationToken);

            if (existingDepartments != departmentIds.Count)
                return Response<bool>.Failure("Hay departamentos inválidos en las líneas.");
        }

        var projectIds = request.Lines
            .Where(l => l.ProjectId.HasValue)
            .Select(l => l.ProjectId!.Value)
            .Distinct()
            .ToList();

        if (projectIds.Count > 0)
        {
            var existingProjects = await unitOfWork.Projects.CountAsync(
                unitOfWork.Projects.Query().Where(p => projectIds.Contains(p.Id)),
                cancellationToken);

            if (existingProjects != projectIds.Count)
                return Response<bool>.Failure("Hay proyectos inválidos en las líneas.");
        }

        mapper.Map(request, entry);
        entry.PeriodId = period?.Id;

        var newLines = mapper.Map<List<JournalEntryLine>>(request.Lines);
        foreach (var line in newLines)
            line.LineGid = Guid.NewGuid();

        for (var i = 0; i < request.Lines.Count; i++)
        {
            var draft = request.Lines[i].PendingDocument;
            if (draft is null) continue;

            var created = await AccountsReceivableDocumentDraftFactory.CreateAsync(unitOfWork, draft, cancellationToken);
            if (created.Error is not null)
                return Response<bool>.Failure(created.Error);

            newLines[i].AppliesToReceivableId = created.Document!.Id;
            newLines[i].CustomerName = $"{created.CustomerCode} - {created.CustomerName}";
        }

        foreach (var oldLine in entry.Lines.ToList())
            await unitOfWork.JournalEntryLines.DeleteAsync(oldLine, cancellationToken);

        ApplyTotals(entry, newLines);
        entry.Lines = newLines;

        await unitOfWork.JournalEntries.UpdateAsync(entry, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }

    private static void ApplyTotals(JournalEntry entry, List<JournalEntryLine> lines)
    {
        entry.DebitTotal = lines.Sum(l => l.Debit);
        entry.CreditTotal = lines.Sum(l => l.Credit);
        entry.DifferenceAmount = entry.DebitTotal - entry.CreditTotal;
    }
}
