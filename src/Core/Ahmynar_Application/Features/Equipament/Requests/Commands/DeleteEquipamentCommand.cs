using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Equipament.Requests.Commands
{
    public class DeleteEquipamentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
