using AutoMapper;
using Countify.Application.Features.PayableConcepts.Commands.CreatePayableConcept;
using Countify.Application.Features.PayableConcepts.Commands.UpdatePayableConcept;
using Countify.Application.Features.PayableConcepts.DTOs;
using Countify.Domain.Entities.AccountsPayable;

namespace Countify.Application.Features.PayableConcepts.Profiles;

public class PayableConceptProfile : Profile
{
    public PayableConceptProfile()
    {
        CreateMap<PayableConcept, PayableConceptDto>()
            // Nomenclatura del legacy invertida: Debit(1) = compra/factura, Credit(2) = pago/abono.
            .ForMember(d => d.TypeName, o => o.MapFrom(s => s.Type == PayableConceptType.Debit ? "Débito" : "Crédito"))
            .ForMember(d => d.AccountCode, o => o.MapFrom(s => s.Account != null ? s.Account.Code : null))
            .ForMember(d => d.AccountName, o => o.MapFrom(s => s.Account != null ? s.Account.Name : null));

        CreateMap<CreatePayableConceptCommand, PayableConcept>();
        CreateMap<UpdatePayableConceptCommand, PayableConcept>();
    }
}
