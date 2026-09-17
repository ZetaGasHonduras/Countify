using AutoMapper;
using Countify.Application.Features.AccountingPeriods.DTOs;
using Countify.Domain.Entities.Accounting;

namespace Countify.Application.Features.AccountingPeriods.Profiles;

public class AccountingPeriodProfile : Profile
{
    public AccountingPeriodProfile()
    {
        CreateMap<AccountingPeriod, AccountingPeriodDto>();
    }
}