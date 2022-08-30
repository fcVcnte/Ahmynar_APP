using Ahmynar_Application.DTOs.Equipament;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Equipament.Requests.Commands
{
    public class UpdateEquipamentCommand : IRequest<Unit>
    {
        public UpdateEquipamentDto EquipamentDto { get; set; }
    }
}
