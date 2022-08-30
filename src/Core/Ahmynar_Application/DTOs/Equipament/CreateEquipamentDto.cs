using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Equipament
{
    public class CreateEquipamentDto : IEquipamentDto
    {
        public Ahmynar_Domain.Enums.TypeEquipament TypeEquipament { get; set; }
        public string Description { get; set; }
        public string? Specs { get; set; }
        public string? Acessories { get; set; }
        public string? Obs { get; set; }
        public int CustomerId { get; set; }
    }
}
