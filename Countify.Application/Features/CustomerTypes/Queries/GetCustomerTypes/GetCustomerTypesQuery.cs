using AutoMapper;
using Countify.Application.Features.CustomerTypes.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.CustomerTypes.Queries.GetCustomerTypes;

public class GetCustomerTypesQuery : IRequest<Response<List<CustomerTypeDto>>>;

public class GetCustomerTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCustomerTypesQuery, Response<List<CustomerTypeDto>>>
{
    public async Task<Response<List<CustomerTypeDto>>> Handle(
        GetCustomerTypesQuery request, CancellationToken cancellationToken)
    {
        var customerTypes = await unitOfWork.CustomerTypes.ToListAsync(
            unitOfWork.CustomerTypes.Query()
                .Include(ct => ct.AccountingAccount)
                .OrderBy(ct => ct.Name),
            cancellationToken);

        return Response<List<CustomerTypeDto>>.Success(
            mapper.Map<List<CustomerTypeDto>>(customerTypes));
    }
}