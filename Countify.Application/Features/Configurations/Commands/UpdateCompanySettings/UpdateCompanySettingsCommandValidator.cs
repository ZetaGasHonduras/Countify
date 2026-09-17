using FluentValidation;

namespace Countify.Application.Features.Configurations.Commands.UpdateCompanySettings;

public class UpdateCompanySettingsCommandValidator : AbstractValidator<UpdateCompanySettingsCommand>
{
    public UpdateCompanySettingsCommandValidator()
    {
        RuleFor(x => x.FiscalYear).InclusiveBetween(2000, 2100);

        RuleFor(x => x)
            .Must(x => !x.RequireDepartments || x.UseDepartments)
            .WithMessage("Si los departamentos son obligatorios deben estar activados.");
        RuleFor(x => x)
            .Must(x => !x.RequireProjects || x.UseProjects)
            .WithMessage("Si los proyectos son obligatorios deben estar activados.");
        RuleFor(x => x)
            .Must(x => !x.RequireSubProjects || x.UseSubProjects)
            .WithMessage("Si los subproyectos son obligatorios deben estar activados.");
        RuleFor(x => x)
            .Must(x => !x.RequireConceptTypes || x.UseConceptTypes)
            .WithMessage("Si los tipos de concepto son obligatorios deben estar activados.");
    }
}