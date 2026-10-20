using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PayableConcepts.Commands.DeletePayableConcept;

public class DeletePayableConceptCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeletePayableConceptCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePayableConceptCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeletePayableConceptCommand request, CancellationToken cancellationToken)
    {
        var concept = await unitOfWork.PayableConcepts.GetByIdAsync(request.Id, cancellationToken);
        if (concept is null)
            return Response<bool>.NotFound($"Concepto {request.Id} no encontrado.");

        await unitOfWork.PayableConcepts.DeleteAsync(concept, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
