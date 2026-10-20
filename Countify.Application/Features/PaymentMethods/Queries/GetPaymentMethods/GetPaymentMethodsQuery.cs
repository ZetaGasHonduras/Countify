using AutoMapper;
using Countify.Application.Features.PaymentMethods.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PaymentMethods.Queries.GetPaymentMethods;

public class GetPaymentMethodsQuery : IRequest<Response<List<PaymentMethodDto>>>;

public class GetPaymentMethodsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetPaymentMethodsQuery, Response<List<PaymentMethodDto>>>
{
    public async Task<Response<List<PaymentMethodDto>>> Handle(
        GetPaymentMethodsQuery request, CancellationToken cancellationToken)
    {
        var methods = await unitOfWork.PaymentMethods.ToListAsync(
            unitOfWork.PaymentMethods.Query().OrderBy(m => m.Name),
            cancellationToken);

        return Response<List<PaymentMethodDto>>.Success(
            mapper.Map<List<PaymentMethodDto>>(methods));
    }
}
