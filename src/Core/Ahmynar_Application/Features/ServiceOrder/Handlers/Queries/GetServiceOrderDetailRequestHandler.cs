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
    public class GetServiceOrderDetailRequestHandler : IRequestHandler<GetServiceOrderDetailRequest, ServiceOrderDto>
    {
        private readonly IServiceOrderRepository _serviceOrderRepo;
        private readonly IMapper _mapper;

        public GetServiceOrderDetailRequestHandler(IServiceOrderRepository serviceOrderRepo, IMapper mapper)
        {
            _serviceOrderRepo = serviceOrderRepo;
            _mapper = mapper;
        }

        public async Task<ServiceOrderDto> Handle(GetServiceOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var serviceOrder = await _serviceOrderRepo.GetByIdAsync(request.Id);
            return _mapper.Map<ServiceOrderDto>(serviceOrder);
        }
    }
}
