using Ahmynar_Application.DTOs.Product;
using Ahmynar_Application.Features.Product.Requests.Queries;
using Ahmynar_Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Product.Handlers.Queries
{
    public class GetProductsListRequestHandler : IRequestHandler<GetProductsListRequest, List<ProductDto>>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public GetProductsListRequestHandler(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetProductsListRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepo.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
