using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.DocumentTypes.Commands.CreateDocumentType;

public class CreateDocumentTypeCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
}

public class CreateDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateDocumentTypeCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateDocumentTypeCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.DocumentTypes.ExistsAsync(
            t => t.Code == request.Code, cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El tipo de documento '{request.Code}' ya existe.");

        var documentType = mapper.Map<DocumentType>(request);
        await unitOfWork.DocumentTypes.AddAsync(documentType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(documentType.Id, 201);
    }
}