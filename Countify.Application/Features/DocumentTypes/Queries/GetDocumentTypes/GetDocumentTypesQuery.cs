using AutoMapper;
using Countify.Application.Features.DocumentTypes.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.DocumentTypes.Queries.GetDocumentTypes;

public class GetDocumentTypesQuery : IRequest<Response<List<DocumentTypeDto>>>;

public class GetDocumentTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetDocumentTypesQuery, Response<List<DocumentTypeDto>>>
{
    public async Task<Response<List<DocumentTypeDto>>> Handle(
        GetDocumentTypesQuery request, CancellationToken cancellationToken)
    {
        var documentTypes = await unitOfWork.DocumentTypes.ToListAsync(
            unitOfWork.DocumentTypes.Query().OrderBy(t => t.Code),
            cancellationToken);

        return Response<List<DocumentTypeDto>>.Success(
            mapper.Map<List<DocumentTypeDto>>(documentTypes));
    }
}