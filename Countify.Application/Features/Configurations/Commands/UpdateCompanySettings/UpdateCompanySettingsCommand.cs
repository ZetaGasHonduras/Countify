using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Configurations.Commands.UpdateCompanySettings;

public class UpdateCompanySettingsCommand : IRequest<Response<bool>>
{
    public string CompanyName { get; set; } = string.Empty;
    public string TaxId { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int FiscalYear { get; set; }
    public Guid? DefaultProjectId { get; set; }
    public Guid? DefaultDepartmentId { get; set; }
    public bool UseDepartments { get; set; }
    public bool RequireDepartments { get; set; }
    public bool UseProjects { get; set; }
    public bool RequireProjects { get; set; }
    public bool UseSubProjects { get; set; }
    public bool RequireSubProjects { get; set; }
    public bool UseConceptTypes { get; set; }
    public bool RequireConceptTypes { get; set; }
}

public class UpdateCompanySettingsCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCompanySettingsCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateCompanySettingsCommand request, CancellationToken cancellationToken)
    {
        if (request.DefaultProjectId is not null)
        {
            var projectExists = await unitOfWork.Projects.ExistsAsync(
                p => p.Id == request.DefaultProjectId.Value, cancellationToken);

            if (!projectExists)
                return Response<bool>.Failure("El proyecto predeterminado indicado no existe.");
        }

        if (request.DefaultDepartmentId is not null)
        {
            var departmentExists = await unitOfWork.Departments.ExistsAsync(
                d => d.Id == request.DefaultDepartmentId.Value, cancellationToken);

            if (!departmentExists)
                return Response<bool>.Failure("El departamento predeterminado indicado no existe.");
        }

        var settings = await unitOfWork.CompanySettings.Query()
            .FirstOrDefaultAsync(cancellationToken);

        if (settings is null)
        {
            settings = new CompanySettings
            {
                CompanyName = request.CompanyName.Trim(),
                TaxId = request.TaxId.Trim(),
                Address = request.Address.Trim(),
                Phone = request.Phone.Trim(),
                Mobile = request.Mobile.Trim(),
                Email = request.Email.Trim(),
                FiscalYear = request.FiscalYear,
                DefaultProjectId = request.DefaultProjectId,
                DefaultDepartmentId = request.DefaultDepartmentId,
                UseDepartments = request.UseDepartments,
                RequireDepartments = request.RequireDepartments,
                UseProjects = request.UseProjects,
                RequireProjects = request.RequireProjects,
                UseSubProjects = request.UseSubProjects,
                RequireSubProjects = request.RequireSubProjects,
                UseConceptTypes = request.UseConceptTypes,
                RequireConceptTypes = request.RequireConceptTypes
            };

            await unitOfWork.CompanySettings.AddAsync(settings, cancellationToken);
        }
        else
        {
            settings.CompanyName = request.CompanyName.Trim();
            settings.TaxId = request.TaxId.Trim();
            settings.Address = request.Address.Trim();
            settings.Phone = request.Phone.Trim();
            settings.Mobile = request.Mobile.Trim();
            settings.Email = request.Email.Trim();
            settings.FiscalYear = request.FiscalYear;
            settings.DefaultProjectId = request.DefaultProjectId;
            settings.DefaultDepartmentId = request.DefaultDepartmentId;
            settings.UseDepartments = request.UseDepartments;
            settings.RequireDepartments = request.RequireDepartments;
            settings.UseProjects = request.UseProjects;
            settings.RequireProjects = request.RequireProjects;
            settings.UseSubProjects = request.UseSubProjects;
            settings.RequireSubProjects = request.RequireSubProjects;
            settings.UseConceptTypes = request.UseConceptTypes;
            settings.RequireConceptTypes = request.RequireConceptTypes;

            await unitOfWork.CompanySettings.UpdateAsync(settings, cancellationToken);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
