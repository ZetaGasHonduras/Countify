using AutoMapper;
using Countify.Application.Features.CashRegisters.Commands.CreateCashRegister;
using Countify.Application.Features.CashRegisters.Commands.UpdateCashRegister;
using Countify.Application.Features.CashRegisters.DTOs;
using Countify.Domain.Entities.Billing;

namespace Countify.Application.Features.CashRegisters.Profiles;

public class CashRegisterProfile : Profile
{
    public CashRegisterProfile()
    {
        CreateMap<CashRegister, CashRegisterDto>();
        CreateMap<CreateCashRegisterCommand, CashRegister>();
        CreateMap<UpdateCashRegisterCommand, CashRegister>();
    }
}
