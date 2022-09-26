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
    public class GetServiceDetailRequestHandler : IRequestHandler<GetServiceDetailRequest, ServiceDto>
    {
        private readonly IServiceRepository _serviceRepo;
        private readonly IMapper _mapper;

        public GetServiceDetailRequestHandler(IServiceRepository serviceRepo, IMapper mapper)
        {
            _serviceRepo = serviceRepo;
            _mapper = mapper;
        }

        public async Task<ServiceDto> Handle(GetServiceDetailRequest request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepo.GetByIdAsync(request.Id);
            return _mapper.Map<ServiceDto>(service);
        }
    }
}
