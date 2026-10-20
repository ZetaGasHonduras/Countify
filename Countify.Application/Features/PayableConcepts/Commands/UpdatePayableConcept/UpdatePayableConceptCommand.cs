using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PayableConcepts.Commands.UpdatePayableConcept;

public class UpdatePayableConceptCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public PayableConceptType Type { get; set; } = PayableConceptType.Debit;
    public Guid? AccountId { get; set; }
    public bool IsInactive { get; set; }
    public bool GeneratePosting { get; set; }
    public bool IsPayment { get; set; }
    public string? Observations { get; set; }
}

public class UpdatePayableConceptCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdatePayableConceptCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdatePayableConceptCommand request, CancellationToken cancellationToken)
    {
        var concept = await unitOfWork.PayableConcepts.GetByIdAsync(request.Id, cancellationToken);
        if (concept is null)
            return Response<bool>.NotFound($"Concepto {request.Id} no encontrado.");

        var exists = await unitOfWork.PayableConcepts.ExistsAsync(
            c => c.Description == request.Description.Trim() && c.Id != request.Id, cancellationToken);

        if (exists)
            return Response<bool>.Failure($"El concepto '{request.Description}' ya existe.");

        mapper.Map(request, concept);
        await unitOfWork.PayableConcepts.UpdateAsync(concept, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
