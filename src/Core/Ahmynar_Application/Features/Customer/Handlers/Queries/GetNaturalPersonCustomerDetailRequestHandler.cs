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
    public class GetNaturalPersonCustomerDetailRequestHandler : IRequestHandler<GetNaturalPersonCustomerDetailRequest, NaturalPersonCustomerDto>
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public GetNaturalPersonCustomerDetailRequestHandler(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<NaturalPersonCustomerDto> Handle(GetNaturalPersonCustomerDetailRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepo.GetByIdAsync(request.Id);
            return _mapper.Map<NaturalPersonCustomerDto>(customer);
        }
    }
}
