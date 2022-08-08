using Ahmynar_Application.DTOs.Product;
using MediatR;
using System.Collections.Generic;

namespace Ahmynar_Application.Features.Product.Requests.Queries
{
    public class GetProductsListRequest : IRequest<List<ProductDto>>
    {
    }
}
