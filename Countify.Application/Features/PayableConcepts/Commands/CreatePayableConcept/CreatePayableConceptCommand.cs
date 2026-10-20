using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PayableConcepts.Commands.CreatePayableConcept;

public class CreatePayableConceptCommand : IRequest<Response<Guid>>
{
    public string Description { get; set; } = string.Empty;
    public PayableConceptType Type { get; set; } = PayableConceptType.Debit;
    public Guid? AccountId { get; set; }
    public bool IsInactive { get; set; }
    public bool GeneratePosting { get; set; }
    public bool IsPayment { get; set; }
    public string? Observations { get; set; }
}

public class CreatePayableConceptCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreatePayableConceptCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreatePayableConceptCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.PayableConcepts.ExistsAsync(
            c => c.Description == request.Description.Trim(), cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El concepto '{request.Description}' ya existe.");

        var concept = mapper.Map<PayableConcept>(request);
        await unitOfWork.PayableConcepts.AddAsync(concept, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(concept.Id, 201);
    }
}
