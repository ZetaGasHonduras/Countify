using AutoMapper;
using Countify.Application.Features.AccountsReceivableConcepts.Commands.CreateAccountsReceivableConcept;
using Countify.Application.Features.AccountsReceivableConcepts.Commands.UpdateAccountsReceivableConcept;
using Countify.Application.Features.AccountsReceivableConcepts.DTOs;
using Countify.Domain.Entities.AccountsReceivable;

namespace Countify.Application.Features.AccountsReceivableConcepts.Profiles;

public class AccountsReceivableConceptProfile : Profile
{
    public AccountsReceivableConceptProfile()
    {
        CreateMap<AccountsReceivableConcept, AccountsReceivableConceptDto>()
            .ForMember(d => d.TypeName, o => o.MapFrom(s => s.Type == AccountsReceivableConceptType.Debit ? "Débito" : "Crédito"))
            .ForMember(d => d.AccountCode, o => o.MapFrom(s => s.Account != null ? s.Account.Code : null))
            .ForMember(d => d.AccountName, o => o.MapFrom(s => s.Account != null ? s.Account.Name : null));

        CreateMap<CreateAccountsReceivableConceptCommand, AccountsReceivableConcept>();
        CreateMap<UpdateAccountsReceivableConceptCommand, AccountsReceivableConcept>();
    }
}