using Ahmynar_Application.DTOs.Service;
using Ahmynar_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Service.Requests.Commands
{
    public class CreateServiceCommand : IRequest<BaseCommandResponse>
    {
        public CreateServiceDto ServiceDto { get; set; }
    }
}
