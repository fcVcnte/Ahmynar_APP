using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Customer;
using Ahmynar_Application.Features.Customer.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Customer.Handlers.Queries
{
    public class GetCustomersListRequestHandler : IRequestHandler<GetCustomersListRequest, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public GetCustomersListRequestHandler(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomersListRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepo.GetAllAsync();
            return _mapper.Map<List<CustomerDto>>(customers);
        }
    }
}
