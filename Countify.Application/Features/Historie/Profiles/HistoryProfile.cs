using AutoMapper;
using Countify.Application.Features.Historie.DTOs;
using Countify.Domain.Entities.Audit;

namespace Countify.Application.Features.Historie.Profiles;

public class HistoryProfile : Profile
{
    public HistoryProfile()
    {
        CreateMap<History, HistoryDto>();
    }
}