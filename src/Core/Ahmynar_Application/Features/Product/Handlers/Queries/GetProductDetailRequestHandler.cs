using Ahmynar_Application.DTOs.Product;
using Ahmynar_Application.Features.Product.Requests.Queries;
using Ahmynar_Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Product.Handlers.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailRequest, ProductDto>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public GetProductDetailRequestHandler(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.Id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
