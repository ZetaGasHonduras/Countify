using AutoMapper;
using Countify.Application.Features.Products.Commands.CreateProduct;
using Countify.Application.Features.Products.Commands.UpdateProduct;
using Countify.Application.Features.Products.DTOs;
using Countify.Domain.Entities.Accounting;

namespace Countify.Application.Features.Products.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}