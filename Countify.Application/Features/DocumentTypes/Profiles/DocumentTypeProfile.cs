using AutoMapper;
using Countify.Application.Features.DocumentTypes.Commands.CreateDocumentType;
using Countify.Application.Features.DocumentTypes.Commands.UpdateDocumentType;
using Countify.Application.Features.DocumentTypes.DTOs;
using Countify.Domain.Entities.Accounting;

namespace Countify.Application.Features.DocumentTypes.Profiles;

public class DocumentTypeProfile : Profile
{
    public DocumentTypeProfile()
    {
        CreateMap<DocumentType, DocumentTypeDto>();

        CreateMap<CreateDocumentTypeCommand, DocumentType>();

        CreateMap<UpdateDocumentTypeCommand, DocumentType>();
    }
}