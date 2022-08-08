using Ahmynar_Application.DTOs.Product;
using MediatR;

namespace Ahmynar_Application.Features.Product.Requests.Queries
{
    public class GetProductDetailRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
