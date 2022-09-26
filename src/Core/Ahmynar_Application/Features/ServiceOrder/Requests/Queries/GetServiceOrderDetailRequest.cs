using Ahmynar_Application.DTOs.ServiceOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.ServiceOrder.Requests.Queries
{
    public class GetServiceOrderDetailRequest : IRequest<ServiceOrderDto>
    {
        public int Id { get; set; }
    }
}
