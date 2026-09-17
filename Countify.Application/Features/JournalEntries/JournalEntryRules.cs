using Countify.Application.Features.JournalEntries.DTOs;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Enums;

namespace Countify.Application.Features.JournalEntries;

internal static class JournalEntryRules
{
    public static string? Validate(
        bool allowUnbalanced,
        IEnumerable<JournalEntryLineRequest> lines,
        CompanySettings settings)
    {
        var list = lines.ToList();
        if (list.Count == 0) return "Debe incluir al menos una línea.";

        foreach (var line in list)
        {
            EntryConceptType? conceptType = null;

            if (line.EntryConceptType.HasValue)
            {
                if (!Enum.IsDefined(typeof(EntryConceptType), line.EntryConceptType.Value))
                    return "El tipo de concepto contable no es válido.";

                conceptType = (EntryConceptType)line.EntryConceptType.Value;
            }

            var error = ValidateLine(
                line.AccountId,
                line.DepartmentId,
                line.ProjectId,
                line.SubProjectId,
                conceptType,
                line.Debit,
                line.Credit,
                settings);

            if (error is not null) return error;
        }

        return ValidateBalance(allowUnbalanced, list.Sum(l => l.Debit), list.Sum(l => l.Credit));
    }

    public static string? Validate(
        bool allowUnbalanced,
        IEnumerable<JournalEntryLine> lines,
        CompanySettings settings)
    {
        var list = lines.ToList();
        if (list.Count == 0) return "Debe incluir al menos una línea.";

        foreach (var line in list)
        {
            var error = ValidateLine(
                line.AccountId,
                line.DepartmentId,
                line.ProjectId,
                line.SubProjectId,
                line.EntryConceptType,
                line.Debit,
                line.Credit,
                settings);

            if (error is not null) return error;
        }

        return ValidateBalance(allowUnbalanced, list.Sum(l => l.Debit), list.Sum(l => l.Credit));
    }

    private static string? ValidateLine(
        Guid accountId,
        Guid? departmentId,
        Guid? projectId,
        Guid? subProjectId,
        EntryConceptType? conceptType,
        decimal debit,
        decimal credit,
        CompanySettings settings)
    {
        if (accountId == Guid.Empty) return "Cada línea debe indicar una cuenta contable.";
        if (debit < 0 || credit < 0) return "Los montos no pueden ser negativos.";
        if (debit > 0 && credit > 0) return "Una línea no puede tener débito y crédito a la vez.";
        if (debit == 0 && credit == 0) return "Cada línea debe tener débito o crédito mayor que cero.";

        var departmentError = ValidateDimension(
            settings.UseDepartments, settings.RequireDepartments, departmentId, "El departamento");
        if (departmentError is not null) return departmentError;

        var projectError = ValidateDimension(
            settings.UseProjects, settings.RequireProjects, projectId, "El proyecto");
        if (projectError is not null) return projectError;

        var subProjectError = ValidateDimension(
            settings.UseSubProjects, settings.RequireSubProjects, subProjectId, "El subproyecto");
        if (subProjectError is not null) return subProjectError;

        var conceptTypeError = ValidateDimension(
            settings.UseConceptTypes, settings.RequireConceptTypes, conceptType, "El tipo de concepto");
        if (conceptTypeError is not null) return conceptTypeError;

        return null;
    }

    private static string? ValidateDimension(
        bool use, bool required, object? value, string name)
    {
        if (!use)
        {
            if (value is not null)
                return $"{name} no está activado en la configuración.";

            return null;
        }

        if (required && value is null)
            return $"{name} es obligatorio.";

        return null;
    }

    private static string? ValidateBalance(bool allowUnbalanced, decimal debitTotal, decimal creditTotal)
        => !allowUnbalanced && debitTotal != creditTotal
            ? "La partida no cuadra: el total de débitos debe ser igual al de créditos."
            : null;
}