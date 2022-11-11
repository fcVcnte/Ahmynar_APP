using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Product.Requests.Commands
{
    public class CheckOutProductCommand : IRequest
    {
        public int Id { get; set; }
        public int QuantityOut { get; set; }
    }
}
