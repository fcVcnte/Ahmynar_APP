using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.ServiceOrder.Requests.Commands
{
    public class DeleteServiceOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
