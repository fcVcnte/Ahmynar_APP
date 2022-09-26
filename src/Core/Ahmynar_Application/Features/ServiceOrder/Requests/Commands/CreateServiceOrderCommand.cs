using Ahmynar_Application.DTOs.ServiceOrder;
using Ahmynar_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.ServiceOrder.Requests.Commands
{
    public class CreateServiceOrderCommand : IRequest<BaseCommandResponse>
    {
        public CreateServiceOrderDto ServiceOrderDto { get; set; }
    }
}
