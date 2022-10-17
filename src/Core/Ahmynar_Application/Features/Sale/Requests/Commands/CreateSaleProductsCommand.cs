using Ahmynar_Application.DTOs.Sale;
using Ahmynar_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Sale.Requests.Commands
{
    public class CreateSaleProductsCommand : IRequest<BaseCommandResponse>
    {
        public CreateSaleProductsDto SaleProductsDto { get; set; }
    }
}
