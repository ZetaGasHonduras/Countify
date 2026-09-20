using AutoMapper;
using Countify.Application.Features.ProductAccounts.Commands.CreateProductAccount;
using Countify.Application.Features.ProductAccounts.Commands.UpdateProductAccount;
using Countify.Application.Features.ProductAccounts.DTOs;
using Countify.Domain.Entities.Accounting;

namespace Countify.Application.Features.ProductAccounts.Profiles;

public class ProductAccountProfile : Profile
{
    public ProductAccountProfile()
    {
        CreateMap<ProductAccount, ProductAccountDto>()
            .ForMember(d => d.ProductCode, o => o.MapFrom(s => s.Product != null ? s.Product.Code : string.Empty))
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product != null ? s.Product.Name : string.Empty))
            .ForMember(d => d.QualityName, o => o.MapFrom(s => s.Quality != null ? s.Quality.Name : null))
            .ForMember(d => d.InventoryAccountCode, o => o.MapFrom(s => s.InventoryAccount != null ? s.InventoryAccount.Code : string.Empty))
            .ForMember(d => d.InventoryAccountName, o => o.MapFrom(s => s.InventoryAccount != null ? s.InventoryAccount.Name : string.Empty))
            .ForMember(d => d.IncomeAccountCode, o => o.MapFrom(s => s.IncomeAccount != null ? s.IncomeAccount.Code : string.Empty))
            .ForMember(d => d.IncomeAccountName, o => o.MapFrom(s => s.IncomeAccount != null ? s.IncomeAccount.Name : string.Empty))
            .ForMember(d => d.CostAccountCode, o => o.MapFrom(s => s.CostAccount != null ? s.CostAccount.Code : string.Empty))
            .ForMember(d => d.CostAccountName, o => o.MapFrom(s => s.CostAccount != null ? s.CostAccount.Name : string.Empty));

        CreateMap<CreateProductAccountCommand, ProductAccount>();
        CreateMap<UpdateProductAccountCommand, ProductAccount>();
    }
}