using AutoMapper;
using Countify.Application.Features.PaymentMethods.Commands.CreatePaymentMethod;
using Countify.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod;
using Countify.Application.Features.PaymentMethods.DTOs;
using Countify.Domain.Entities.Billing;

namespace Countify.Application.Features.PaymentMethods.Profiles;

public class PaymentMethodProfile : Profile
{
    public PaymentMethodProfile()
    {
        CreateMap<PaymentMethod, PaymentMethodDto>();
        CreateMap<CreatePaymentMethodCommand, PaymentMethod>();
        CreateMap<UpdatePaymentMethodCommand, PaymentMethod>();
    }
}
