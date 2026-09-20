using AutoMapper;
using Countify.Application.Features.Qualities.Commands.CreateQuality;
using Countify.Application.Features.Qualities.Commands.UpdateQuality;
using Countify.Application.Features.Qualities.DTOs;
using Countify.Domain.Entities.Accounting;

namespace Countify.Application.Features.Qualities.Profiles;

public class QualityProfile : Profile
{
    public QualityProfile()
    {
        CreateMap<Quality, QualityDto>();
        CreateMap<CreateQualityCommand, Quality>();
        CreateMap<UpdateQualityCommand, Quality>();
    }
}