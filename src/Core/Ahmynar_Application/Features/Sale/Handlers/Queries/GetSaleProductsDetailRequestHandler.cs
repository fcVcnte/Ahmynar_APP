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
    public class GetSaleProductsDetailRequestHandler : IRequestHandler<GetSaleProductsDetailRequest, SaleProductsDto>
    {
        private readonly ISaleRepository _saleRepo;
        private readonly IMapper _mapper;

        public GetSaleProductsDetailRequestHandler(ISaleRepository saleRepo, IMapper mapper)
        {
            _saleRepo = saleRepo;
            _mapper = mapper;
        }

        public async Task<SaleProductsDto> Handle(GetSaleProductsDetailRequest request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepo.GetByIdAsync(request.Id);
            return _mapper.Map<SaleProductsDto>(sale);
        }
    }
}
