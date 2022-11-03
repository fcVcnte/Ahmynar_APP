using Ahmynar_Application.DTOs.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Service.Requests.Queries
{
    public class GetServicesListRequest : IRequest<List<ServiceDto>>
    {
    }
}
