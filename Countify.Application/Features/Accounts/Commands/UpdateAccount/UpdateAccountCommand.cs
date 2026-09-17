using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Accounts.Commands.UpdateAccount;

public class UpdateAccountCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
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

public class UpdateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateAccountCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await unitOfWork.Accounts.GetByIdAsync(request.Id, cancellationToken);
        if (account is null)
            return Response<bool>.NotFound($"Cuenta {request.Id} no encontrada.");

        var codeInUse = await unitOfWork.Accounts.ExistsAsync(
            a => a.Code == request.Code && a.Id != request.Id, cancellationToken);

        if (codeInUse)
            return Response<bool>.Failure($"La cuenta '{request.Code}' ya existe.");

        mapper.Map(request, account);
        await unitOfWork.Accounts.UpdateAsync(account, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}