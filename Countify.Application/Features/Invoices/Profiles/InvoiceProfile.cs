using AutoMapper;
using Countify.Application.Features.Invoices.Commands.CreateInvoice;
using Countify.Application.Features.Invoices.Commands.UpdateInvoice;
using Countify.Application.Features.Invoices.DTOs;
using Countify.Domain.Entities.Billing;

namespace Countify.Application.Features.Invoices.Profiles;

public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<Invoice, InvoiceDto>()
            .ForMember(d => d.CustomerCode, o => o.MapFrom(s => s.Customer != null ? s.Customer.Code : null))
            .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Department != null ? s.Department.Name : null))
            .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project != null ? s.Project.Name : null))
            .ForMember(d => d.CurrencyCode, o => o.MapFrom(s => s.Currency != null ? s.Currency.Code : null))
            .ForMember(d => d.PaymentTerms, o => o.MapFrom(s => (int)s.PaymentTerms))
            .ForMember(d => d.ReceivableDocumentNo, o => o.MapFrom(s => s.ReceivableDocument != null ? s.ReceivableDocument.DocumentNo : (int?)null));

        CreateMap<InvoiceLine, InvoiceLineDto>();

        CreateMap<CreateInvoiceCommand.InvoiceLineInput, InvoiceLine>();
        CreateMap<CreateInvoiceCommand, Invoice>()
            .ForMember(d => d.Lines, o => o.MapFrom(s => s.Lines));

        // Las líneas se reemplazan a mano en el handler; el resto se copia directo.
        CreateMap<UpdateInvoiceCommand, Invoice>()
            .ForMember(d => d.Lines, o => o.Ignore())
            .ForMember(d => d.PaymentTerms, o => o.Ignore());

        CreateMap<Domain.Entities.Billing.InvoicePayment, InvoicePaymentDto>();
        CreateMap<Commands.SetInvoicePayments.SetInvoicePaymentsCommand.InvoicePaymentInput,
            Domain.Entities.Billing.InvoicePayment>();
    }
}
