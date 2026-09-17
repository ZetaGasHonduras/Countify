using AutoMapper;
using Countify.Application.Features.JournalEntries.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry;

public class CreateJournalEntryCommand : IRequest<Response<Guid>>
{
    public Guid TypeId { get; set; }
    public Guid? PeriodId { get; set; }
    public DateTime ReferenceDate { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string Concept { get; set; } = string.Empty;
    public string? Observations { get; set; }
    public string? Code { get; set; }
    public List<JournalEntryLineRequest> Lines { get; set; } = [];
}

public class CreateJournalEntryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateJournalEntryCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateJournalEntryCommand request, CancellationToken cancellationToken)
    {
        var type = await unitOfWork.DocumentTypes.GetByIdAsync(request.TypeId, cancellationToken);
        if (type is null)
            return Response<Guid>.NotFound($"Tipo de documento {request.TypeId} no encontrado.");

        var period = await unitOfWork.AccountingPeriods.Query()
            .Where(p => p.Month.Month == request.ReferenceDate.Month
                     && p.Month.Year == request.ReferenceDate.Year)
            .FirstOrDefaultAsync(cancellationToken);

        if (period is not null && period.IsClosed)
            return Response<Guid>.Failure($"El período {period.Month:yyyy-MM} está cerrado; no se pueden crear partidas.");

        var settings = await unitOfWork.CompanySettings.Query()
            .FirstOrDefaultAsync(cancellationToken);

        if (settings is null)
            return Response<Guid>.Failure("No hay configuración de la empresa.");

        var ruleError = JournalEntryRules.Validate(true, request.Lines, settings);
        if (ruleError is not null)
            return Response<Guid>.Failure(ruleError);

        var accountIds = request.Lines.Select(l => l.AccountId).Distinct().ToList();
        var existingAccountIds = await unitOfWork.Accounts.Query()
            .Where(a => accountIds.Contains(a.Id))
            .Select(a => a.Id)
            .ToListAsync(cancellationToken);

        if (existingAccountIds.Count != accountIds.Count)
            return Response<Guid>.Failure("Hay cuentas contables inválidas en las líneas.");

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
                return Response<Guid>.Failure("Hay departamentos inválidos en las líneas.");
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
                return Response<Guid>.Failure("Hay proyectos inválidos en las líneas.");
        }

        var periodEntries = unitOfWork.JournalEntries.Query();
        var maxNumber = period is null
            ? await periodEntries.Select(e => (int?)e.EntryNumber).MaxAsync(cancellationToken)
            : await periodEntries
                .Where(e => e.PeriodId == period.Id)
                .Select(e => (int?)e.EntryNumber)
                .MaxAsync(cancellationToken);

        var entry = mapper.Map<JournalEntry>(request);
        entry.EntryGid = Guid.NewGuid();
        entry.EntryNumber = (maxNumber ?? 0) + 1;
        entry.SourceModule = SourceModule.Manually;
        entry.Status = JournalEntryStatus.Posted;
        entry.PeriodId = period?.Id;

        var lines = mapper.Map<List<JournalEntryLine>>(request.Lines);
        foreach (var line in lines)
            line.LineGid = Guid.NewGuid();

        ApplyTotals(entry, lines);
        entry.Lines = lines;

        await unitOfWork.JournalEntries.AddAsync(entry, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(entry.Id, 201);
    }

    private static void ApplyTotals(JournalEntry entry, List<JournalEntryLine> lines)
    {
        entry.DebitTotal = lines.Sum(l => l.Debit);
        entry.CreditTotal = lines.Sum(l => l.Credit);
        entry.DifferenceAmount = entry.DebitTotal - entry.CreditTotal;
    }
}