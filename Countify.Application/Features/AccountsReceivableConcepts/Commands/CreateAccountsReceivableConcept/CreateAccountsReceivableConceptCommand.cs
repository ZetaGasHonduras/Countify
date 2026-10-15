using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountsReceivableConcepts.Commands.CreateAccountsReceivableConcept;

public class CreateAccountsReceivableConceptCommand : IRequest<Response<Guid>>
{
    public string Description { get; set; } = string.Empty;
    public AccountsReceivableConceptType Type { get; set; } = AccountsReceivableConceptType.Debit;
    public Guid? AccountId { get; set; }
    public bool IsInactive { get; set; }
    public bool GeneratePosting { get; set; }
    public bool IsReceipt { get; set; }
    public bool IsFiscalNote { get; set; }
    public string? Observations { get; set; }
}

public class CreateAccountsReceivableConceptCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateAccountsReceivableConceptCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateAccountsReceivableConceptCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.AccountsReceivableConcepts.ExistsAsync(
            c => c.Description == request.Description.Trim(), cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El concepto '{request.Description}' ya existe.");

        var concept = mapper.Map<AccountsReceivableConcept>(request);
        await unitOfWork.AccountsReceivableConcepts.AddAsync(concept, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(concept.Id, 201);
    }
}