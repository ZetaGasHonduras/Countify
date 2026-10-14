using AutoMapper;
using Countify.Application.Features.AccountsReceivableDocuments.Commands.CreateAccountsReceivableDocument;
using Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateAccountsReceivableDocument;
using Countify.Application.Features.AccountsReceivableDocuments.DTOs;
using Countify.Domain.Entities.AccountsReceivable;

namespace Countify.Application.Features.AccountsReceivableDocuments.Profiles;

public class AccountsReceivableDocumentProfile : Profile
{
    public AccountsReceivableDocumentProfile()
    {
        CreateMap<AccountsReceivableDocument, AccountsReceivableDocumentDto>()
            .ForMember(d => d.CustomerCode, o => o.MapFrom(s => s.Customer != null ? s.Customer.Code : null))
            .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer != null ? s.Customer.Name : null))
            .ForMember(d => d.ConceptDescription, o => o.MapFrom(s => s.Concept != null ? s.Concept.Description : null))
            .ForMember(d => d.IsCredit, o => o.MapFrom(s => s.Concept != null && s.Concept.Type == AccountsReceivableConceptType.Credit))
            .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Department != null ? s.Department.Name : null))
            .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project != null ? s.Project.Name : null))
            .ForMember(d => d.CurrencyCode, o => o.MapFrom(s => s.Currency != null ? s.Currency.Code : null))
            .ForMember(d => d.AmountLocal, o => o.MapFrom(s => Math.Round(s.Amount * s.ExchangeRate, 2)))
            .ForMember(d => d.OutstandingAmount, o => o.MapFrom(s =>
                s.IsVoided || (s.Concept != null && s.Concept.Type == AccountsReceivableConceptType.Credit)
                    ? 0
                    : s.Amount))
            .ForMember(d => d.DifferenceAmount, o => o.Ignore());

        CreateMap<AccountsReceivableDocumentLine, AccountsReceivableDocumentLineDto>()
            .ForMember(d => d.AppliedDocumentId, o => o.MapFrom(s => s.AppliedDocumentId))
            .ForMember(d => d.AppliedDocumentNo, o => o.MapFrom(s => s.AppliedDocument != null ? s.AppliedDocument.DocumentNo : 0))
            .ForMember(d => d.AppliedReference, o => o.MapFrom(s => s.AppliedDocument != null ? s.AppliedDocument.Reference : null))
            .ForMember(d => d.AppliedConcept, o => o.MapFrom(s => s.AppliedDocument != null && s.AppliedDocument.Concept != null ? s.AppliedDocument.Concept.Description : null))
            .ForMember(d => d.AppliedDate, o => o.MapFrom(s => s.AppliedDocument != null ? s.AppliedDocument.Date : DateTime.MinValue))
            .ForMember(d => d.AppliedCurrencyCode, o => o.MapFrom(s => s.AppliedDocument != null && s.AppliedDocument.Currency != null ? s.AppliedDocument.Currency.Code : null))
            .ForMember(d => d.AppliedAmount, o => o.MapFrom(s => s.AppliedDocument != null ? s.AppliedDocument.Amount : 0));

        CreateMap<CreateAccountsReceivableDocumentCommand, AccountsReceivableDocument>();
        CreateMap<UpdateAccountsReceivableDocumentCommand, AccountsReceivableDocument>();
    }
}