using AutoMapper;
using Countify.Application.Features.CustomerTypes.Commands.CreateCustomerType;
using Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType;
using Countify.Application.Features.CustomerTypes.DTOs;
using Countify.Domain.Entities.AccountsReceivable;

namespace Countify.Application.Features.CustomerTypes.Profiles;

public class CustomerTypeProfile : Profile
{
    public CustomerTypeProfile()
    {
        CreateMap<CustomerType, CustomerTypeDto>()
            .ForMember(d => d.AccountingAccountCode, o => o.MapFrom(s => s.AccountingAccount != null ? s.AccountingAccount.Code : null))
            .ForMember(d => d.AccountingAccountName, o => o.MapFrom(s => s.AccountingAccount != null ? s.AccountingAccount.Name : null));

        CreateMap<CreateCustomerTypeCommand, CustomerType>();
        CreateMap<UpdateCustomerTypeCommand, CustomerType>();
    }
}