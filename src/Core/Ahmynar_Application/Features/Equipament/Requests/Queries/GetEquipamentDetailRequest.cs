using Ahmynar_Application.DTOs.Equipament;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Equipament.Requests.Queries
{
    public class GetEquipamentDetailRequest : IRequest<EquipamentDto>
    {
        public int Id { get; set; }
    }
}
