using AutoMapper;
using Countify.Application.Features.Cashiers.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Cashiers.Queries.GetCashiers;

public class GetCashiersQuery : IRequest<Response<List<CashierDto>>>;

public class GetCashiersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCashiersQuery, Response<List<CashierDto>>>
{
    public async Task<Response<List<CashierDto>>> Handle(
        GetCashiersQuery request, CancellationToken cancellationToken)
    {
        var cashiers = await unitOfWork.Cashiers.ToListAsync(
            unitOfWork.Cashiers.Query().OrderBy(c => c.Name),
            cancellationToken);

        var userIds = cashiers
            .Where(c => c.UserId is not null)
            .Select(c => c.UserId!)
            .Distinct()
            .ToList();

        var userNames = new Dictionary<string, string>();
        if (userIds.Count > 0)
        {
            var users = await unitOfWork.Users.Query()
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync(cancellationToken);
            userNames = users.ToDictionary(u => u.Id, u => u.FullName);
        }

        var dtos = mapper.Map<List<CashierDto>>(cashiers);
        foreach (var dto in dtos)
        {
            if (dto.UserId is { } id)
                dto.UserName = userNames.GetValueOrDefault(id);
        }

        return Response<List<CashierDto>>.Success(dtos);
    }
}
