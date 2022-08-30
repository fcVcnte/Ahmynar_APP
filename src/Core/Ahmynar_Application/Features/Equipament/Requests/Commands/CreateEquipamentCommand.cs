using Ahmynar_Application.DTOs.Equipament;
using Ahmynar_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Equipament.Requests.Commands
{
    public class CreateEquipamentCommand : IRequest<BaseCommandResponse>
    {
        public CreateEquipamentDto EquipamentDto { get; set; }
    }
}
