using AutoMapper;
using Countify.Application.Features.Suppliers.Commands.CreateSupplier;
using Countify.Application.Features.Suppliers.Commands.UpdateSupplier;
using Countify.Application.Features.Suppliers.DTOs;
using Countify.Domain.Entities.AccountsPayable;

namespace Countify.Application.Features.Suppliers.Profiles;

public class SupplierProfile : Profile
{
    public SupplierProfile()
    {
        CreateMap<Supplier, SupplierDto>()
            .ForMember(d => d.SupplierTypeCode, o => o.MapFrom(s => s.SupplierType != null ? s.SupplierType.Code : null))
            .ForMember(d => d.SupplierTypeName, o => o.MapFrom(s => s.SupplierType != null ? s.SupplierType.Name : null))
            .ForMember(d => d.AccountingAccountCode, o => o.MapFrom(s => s.AccountingAccount != null ? s.AccountingAccount.Code : null))
            .ForMember(d => d.AccountingAccountName, o => o.MapFrom(s => s.AccountingAccount != null ? s.AccountingAccount.Name : null));

        CreateMap<SupplierFiscalData, SupplierFiscalDataDto>();

        // FiscalData se sincroniza a mano en los handlers; se ignora aquí.
        CreateMap<CreateSupplierCommand, Supplier>()
            .ForMember(d => d.FiscalData, o => o.Ignore());
        CreateMap<UpdateSupplierCommand, Supplier>()
            .ForMember(d => d.FiscalData, o => o.Ignore());
    }
}
