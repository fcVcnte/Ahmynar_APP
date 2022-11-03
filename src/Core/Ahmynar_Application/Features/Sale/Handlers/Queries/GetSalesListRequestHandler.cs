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
    public class GetSalesListRequestHandler : IRequestHandler<GetSalesListRequest, List<SaleDto>>
    {
        private readonly ISaleRepository _saleRepo;
        private readonly IMapper _mapper;

        public GetSalesListRequestHandler(ISaleRepository saleRepo, IMapper mapper)
        {
            _saleRepo = saleRepo;
            _mapper = mapper;
        }

        public async Task<List<SaleDto>> Handle(GetSalesListRequest request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepo.GetAllAsync();
            return _mapper.Map<List<SaleDto>>(sales);
        }
    }
}
