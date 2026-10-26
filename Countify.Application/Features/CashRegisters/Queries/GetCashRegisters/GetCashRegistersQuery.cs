using AutoMapper;
using Countify.Application.Features.CashRegisters.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.CashRegisters.Queries.GetCashRegisters;

public class GetCashRegistersQuery : IRequest<Response<List<CashRegisterDto>>>;

public class GetCashRegistersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCashRegistersQuery, Response<List<CashRegisterDto>>>
{
    public async Task<Response<List<CashRegisterDto>>> Handle(
        GetCashRegistersQuery request, CancellationToken cancellationToken)
    {
        var registers = await unitOfWork.CashRegisters.ToListAsync(
            unitOfWork.CashRegisters.Query().OrderBy(c => c.Name),
            cancellationToken);

        return Response<List<CashRegisterDto>>.Success(
            mapper.Map<List<CashRegisterDto>>(registers));
    }
}
