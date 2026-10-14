using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountsReceivableConcepts.Commands.UpdateAccountsReceivableConcept;

public class UpdateAccountsReceivableConceptCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public AccountsReceivableConceptType Type { get; set; } = AccountsReceivableConceptType.Debit;
    public Guid? AccountId { get; set; }
    public bool IsInactive { get; set; }
    public bool GeneratePosting { get; set; }
    public string? Observations { get; set; }
}

public class UpdateAccountsReceivableConceptCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateAccountsReceivableConceptCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateAccountsReceivableConceptCommand request, CancellationToken cancellationToken)
    {
        var concept = await unitOfWork.AccountsReceivableConcepts.GetByIdAsync(request.Id, cancellationToken);
        if (concept is null)
            return Response<bool>.NotFound($"Concepto {request.Id} no encontrado.");

        var exists = await unitOfWork.AccountsReceivableConcepts.ExistsAsync(
            c => c.Description == request.Description.Trim() && c.Id != request.Id, cancellationToken);

        if (exists)
            return Response<bool>.Failure($"El concepto '{request.Description}' ya existe.");

        mapper.Map(request, concept);
        await unitOfWork.AccountsReceivableConcepts.UpdateAsync(concept, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}