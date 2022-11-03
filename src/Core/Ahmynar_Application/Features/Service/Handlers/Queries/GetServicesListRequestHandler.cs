using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Service;
using Ahmynar_Application.Features.Service.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Service.Handlers.Queries
{
    public class GetServicesListRequestHandler : IRequestHandler<GetServicesListRequest, List<ServiceDto>>
    {
        private readonly IServiceRepository _serviceRepo;
        private readonly IMapper _mapper;

        public GetServicesListRequestHandler(IServiceRepository serviceRepo, IMapper mapper)
        {
            _serviceRepo = serviceRepo;
            _mapper = mapper;
        }

        public async Task<List<ServiceDto>> Handle(GetServicesListRequest request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepo.GetAllAsync();
            return _mapper.Map<List<ServiceDto>>(services);
        }
    }
}
