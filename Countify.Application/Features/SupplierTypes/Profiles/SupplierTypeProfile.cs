using AutoMapper;
using Countify.Application.Features.SupplierTypes.Commands.CreateSupplierType;
using Countify.Application.Features.SupplierTypes.Commands.UpdateSupplierType;
using Countify.Application.Features.SupplierTypes.DTOs;
using Countify.Domain.Entities.AccountsPayable;

namespace Countify.Application.Features.SupplierTypes.Profiles;

public class SupplierTypeProfile : Profile
{
    public SupplierTypeProfile()
    {
        CreateMap<SupplierType, SupplierTypeDto>()
            .ForMember(d => d.AccountingAccountCode, o => o.MapFrom(s => s.AccountingAccount != null ? s.AccountingAccount.Code : null))
            .ForMember(d => d.AccountingAccountName, o => o.MapFrom(s => s.AccountingAccount != null ? s.AccountingAccount.Name : null));

        CreateMap<CreateSupplierTypeCommand, SupplierType>();
        CreateMap<UpdateSupplierTypeCommand, SupplierType>();
    }
}
