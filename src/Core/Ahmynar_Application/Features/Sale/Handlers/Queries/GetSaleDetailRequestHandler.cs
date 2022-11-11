using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Sale;
using Ahmynar_Application.Features.Sale.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Sale.Handlers.Queries
{
    public class GetSaleDetailRequestHandler : IRequestHandler<GetSaleDetailRequest, SaleDto>
    {
        private readonly ISaleRepository _saleRepo;
        private readonly IMapper _mapper;

        public GetSaleDetailRequestHandler(ISaleRepository saleRepo, IMapper mapper)
        {
            _saleRepo = saleRepo;
            _mapper = mapper;
        }

        public async Task<SaleDto> Handle(GetSaleDetailRequest request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepo.GetByIdAsync(request.Id);
            return _mapper.Map<SaleDto>(sale);
        }
    }
}
