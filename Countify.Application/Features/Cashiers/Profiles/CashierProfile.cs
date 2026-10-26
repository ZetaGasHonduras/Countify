using AutoMapper;
using Countify.Application.Features.Cashiers.Commands.CreateCashier;
using Countify.Application.Features.Cashiers.Commands.UpdateCashier;
using Countify.Application.Features.Cashiers.DTOs;
using Countify.Domain.Entities.Billing;

namespace Countify.Application.Features.Cashiers.Profiles;

public class CashierProfile : Profile
{
    public CashierProfile()
    {
        CreateMap<Cashier, CashierDto>()
            .ForMember(d => d.UserName, opt => opt.Ignore());
        CreateMap<CreateCashierCommand, Cashier>();
        CreateMap<UpdateCashierCommand, Cashier>();
    }
}
