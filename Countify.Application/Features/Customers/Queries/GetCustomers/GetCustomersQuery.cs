using AutoMapper;
using Countify.Application.Features.Customers.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Customers.Queries.GetCustomers;

public class GetCustomersQuery : IRequest<Response<List<CustomerDto>>>;

public class GetCustomersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCustomersQuery, Response<List<CustomerDto>>>
{
    public async Task<Response<List<CustomerDto>>> Handle(
        GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await unitOfWork.Customers.ToListAsync(
            unitOfWork.Customers.Query()
                .Include(c => c.CustomerType)
                .Include(c => c.AccountingAccount)
                .OrderBy(c => c.Name),
            cancellationToken);

        return Response<List<CustomerDto>>.Success(
            mapper.Map<List<CustomerDto>>(customers));
    }
}