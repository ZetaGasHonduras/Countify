using AutoMapper;
using Countify.Application.Features.Configurations.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Configurations.Queries.GetCompanySettings;

public class GetCompanySettingsQuery : IRequest<Response<CompanySettingsDto>>;

public class GetCompanySettingsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCompanySettingsQuery, Response<CompanySettingsDto>>
{
    public async Task<Response<CompanySettingsDto>> Handle(
        GetCompanySettingsQuery request, CancellationToken cancellationToken)
    {
        var settings = await unitOfWork.CompanySettings.Query()
            .FirstOrDefaultAsync(cancellationToken);

        if (settings is null)
            return Response<CompanySettingsDto>.NotFound("No hay configuración de la empresa.");

        return Response<CompanySettingsDto>.Success(mapper.Map<CompanySettingsDto>(settings));
    }
}