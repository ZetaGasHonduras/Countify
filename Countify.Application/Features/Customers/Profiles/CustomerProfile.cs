using AutoMapper;
using Countify.Application.Features.Customers.Commands.CreateCustomer;
using Countify.Application.Features.Customers.Commands.UpdateCustomer;
using Countify.Application.Features.Customers.DTOs;
using Countify.Domain.Entities.AccountsReceivable;

namespace Countify.Application.Features.Customers.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(d => d.CustomerTypeCode, o => o.MapFrom(s => s.CustomerType != null ? s.CustomerType.Code : null))
            .ForMember(d => d.CustomerTypeName, o => o.MapFrom(s => s.CustomerType != null ? s.CustomerType.Name : null))
            .ForMember(d => d.AccountingAccountCode, o => o.MapFrom(s => s.AccountingAccount != null ? s.AccountingAccount.Code : null))
            .ForMember(d => d.AccountingAccountName, o => o.MapFrom(s => s.AccountingAccount != null ? s.AccountingAccount.Name : null));

        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();
    }
}