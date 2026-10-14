using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountsReceivableConcepts.Commands.DeleteAccountsReceivableConcept;

public class DeleteAccountsReceivableConceptCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteAccountsReceivableConceptCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAccountsReceivableConceptCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteAccountsReceivableConceptCommand request, CancellationToken cancellationToken)
    {
        var concept = await unitOfWork.AccountsReceivableConcepts.GetByIdAsync(request.Id, cancellationToken);
        if (concept is null)
            return Response<bool>.NotFound($"Concepto {request.Id} no encontrado.");

        await unitOfWork.AccountsReceivableConcepts.DeleteAsync(concept, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}