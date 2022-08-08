using Ahmynar_Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Product.Requests.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public UpdateProductDto ProductDto { get; set; }
    }
}
