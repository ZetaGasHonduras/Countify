using AutoMapper;
using Countify.Application.Features.PayableDocuments.Commands.CreatePayableDocument;
using Countify.Application.Features.PayableDocuments.Commands.UpdatePayableDocument;
using Countify.Application.Features.PayableDocuments.DTOs;
using Countify.Domain.Entities.AccountsPayable;

namespace Countify.Application.Features.PayableDocuments.Profiles;

public class PayableDocumentProfile : Profile
{
    public PayableDocumentProfile()
    {
        CreateMap<PayableDocument, PayableDocumentDto>()
            .ForMember(d => d.SupplierCode, o => o.MapFrom(s => s.Supplier != null ? s.Supplier.Code : null))
            .ForMember(d => d.SupplierName, o => o.MapFrom(s => s.Supplier != null ? s.Supplier.Name : null))
            .ForMember(d => d.ConceptDescription, o => o.MapFrom(s => s.Concept != null ? s.Concept.Description : null))
            .ForMember(d => d.IsPayment, o => o.MapFrom(s => s.Concept != null && s.Concept.Type == PayableConceptType.Credit))
            .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Department != null ? s.Department.Name : null))
            .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project != null ? s.Project.Name : null))
            .ForMember(d => d.CurrencyCode, o => o.MapFrom(s => s.Currency != null ? s.Currency.Code : null))
            .ForMember(d => d.AmountLocal, o => o.MapFrom(s => Math.Round(s.Amount * s.ExchangeRate, 2)))
            .ForMember(d => d.Total, o => o.MapFrom(s => Math.Round(s.Amount + s.Tax, 2)))
            .ForMember(d => d.TotalLocal, o => o.MapFrom(s => Math.Round(s.Amount * s.ExchangeRate + s.TaxLocal, 2)))
            .ForMember(d => d.OutstandingAmount, o => o.MapFrom(s =>
                s.IsVoided || (s.Concept != null && s.Concept.Type == PayableConceptType.Credit)
                    ? 0
                    : Math.Round(s.Amount + s.Tax, 2)))
            .ForMember(d => d.DifferenceAmount, o => o.Ignore());

        CreateMap<PayableDocumentLine, PayableDocumentLineDto>()
            .ForMember(d => d.AppliedDocumentId, o => o.MapFrom(s => s.AppliedDocumentId))
            .ForMember(d => d.AppliedDocumentNo, o => o.MapFrom(s => s.AppliedDocument != null ? s.AppliedDocument.DocumentNo : 0))
            .ForMember(d => d.AppliedReference, o => o.MapFrom(s => s.AppliedDocument != null ? s.AppliedDocument.Reference : null))
            .ForMember(d => d.AppliedConcept, o => o.MapFrom(s => s.AppliedDocument != null && s.AppliedDocument.Concept != null ? s.AppliedDocument.Concept.Description : null))
            .ForMember(d => d.AppliedDate, o => o.MapFrom(s => s.AppliedDocument != null ? s.AppliedDocument.Date : DateTime.MinValue))
            .ForMember(d => d.AppliedCurrencyCode, o => o.MapFrom(s => s.AppliedDocument != null && s.AppliedDocument.Currency != null ? s.AppliedDocument.Currency.Code : null))
            // El saldo de una compra se mide sobre su total (Amount + Tax).
            .ForMember(d => d.AppliedAmount, o => o.MapFrom(s => s.AppliedDocument != null ? s.AppliedDocument.Amount + s.AppliedDocument.Tax : 0));

        CreateMap<CreatePayableDocumentCommand, PayableDocument>();
        CreateMap<UpdatePayableDocumentCommand, PayableDocument>();
        CreateMap<PayableDocumentAttachment, PayableDocumentAttachmentDto>();
    }
}
