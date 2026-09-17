using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Accounts.Commands.CreateAccount;

public class CreateAccountCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsOperable { get; set; }
    public string? ParentCode { get; set; }
    public int Level { get; set; }
    public string? BudgetLine { get; set; }
    public bool BudgetControlled { get; set; }
    public bool IsAuxCxc { get; set; }
    public bool IsAuxCxp { get; set; }
    public bool IsAuxLoan { get; set; }
    public bool IsAuxAsset { get; set; }
    public bool IsBankAccount { get; set; }
}

public class CreateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateAccountCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.Accounts.ExistsAsync(
            a => a.Code == request.Code, cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"La cuenta '{request.Code}' ya existe.");

        var account = mapper.Map<Account>(request);
        await unitOfWork.Accounts.AddAsync(account, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(account.Id, 201);
    }
}