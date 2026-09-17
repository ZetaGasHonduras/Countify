using AutoMapper;
using Countify.Application.Features.Configurations.DTOs;
using Countify.Domain.Entities.Accounting;

namespace Countify.Application.Features.Configurations.Profiles;

public class SettingsProfile : Profile
{
    public SettingsProfile()
    {
        CreateMap<CompanySettings, CompanySettingsDto>();
    }
}