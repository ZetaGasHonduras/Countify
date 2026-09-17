using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.DocumentTypes.Commands.UpdateDocumentType;

public class UpdateDocumentTypeCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
}

public class UpdateDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateDocumentTypeCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
    {
        var documentType = await unitOfWork.DocumentTypes.GetByIdAsync(request.Id, cancellationToken);
        if (documentType is null)
            return Response<bool>.NotFound($"Tipo de documento {request.Id} no encontrado.");

        var codeInUse = await unitOfWork.DocumentTypes.ExistsAsync(
            t => t.Code == request.Code && t.Id != request.Id, cancellationToken);

        if (codeInUse)
            return Response<bool>.Failure($"El tipo de documento '{request.Code}' ya existe.");

        mapper.Map(request, documentType);
        await unitOfWork.DocumentTypes.UpdateAsync(documentType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}