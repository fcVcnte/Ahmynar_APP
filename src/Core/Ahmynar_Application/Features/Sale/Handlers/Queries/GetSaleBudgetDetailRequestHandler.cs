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
    public class GetSaleBudgetDetailRequestHandler : IRequestHandler<GetSaleBudgetDetailRequest, SaleBudgetDto>
    {
        private readonly ISaleRepository _saleRepo;
        private readonly IMapper _mapper;

        public GetSaleBudgetDetailRequestHandler(ISaleRepository saleRepo, IMapper mapper)
        {
            _saleRepo = saleRepo;
            _mapper = mapper;
        }

        public async Task<SaleBudgetDto> Handle(GetSaleBudgetDetailRequest request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepo.GetByIdAsync(request.Id);
            return _mapper.Map<SaleBudgetDto>(sale);
        }
    }
}
