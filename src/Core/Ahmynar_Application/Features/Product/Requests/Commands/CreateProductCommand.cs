using Ahmynar_Application.DTOs.Product;
using Ahmynar_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Product.Requests.Commands
{
    public class CreateProductCommand : IRequest<BaseCommandResponse>
    {
        public CreateProductDto ProductDto { get; set; }
    }
}
