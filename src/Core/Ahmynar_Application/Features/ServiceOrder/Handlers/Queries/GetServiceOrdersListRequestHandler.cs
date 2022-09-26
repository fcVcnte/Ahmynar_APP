using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.ServiceOrder;
using Ahmynar_Application.Features.ServiceOrder.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.ServiceOrder.Handlers.Queries
{
    public class GetServiceOrdersListRequestHandler : IRequestHandler<GetServiceOrdersListRequest, List<ServiceOrderListDto>>
    {
        private readonly IServiceOrderRepository _serviceOrderRepo;
        private readonly IMapper _mapper;

        public GetServiceOrdersListRequestHandler(IServiceOrderRepository serviceOrderRepo, IMapper mapper)
        {
            _serviceOrderRepo = serviceOrderRepo;
            _mapper = mapper;
        }
        public async Task<List<ServiceOrderListDto>> Handle(GetServiceOrdersListRequest request, CancellationToken cancellationToken)
        {
            var serviceOrders = await _serviceOrderRepo.GetAllAsync();
            return _mapper.Map<List<ServiceOrderListDto>>(serviceOrders);
        }
    }
}
