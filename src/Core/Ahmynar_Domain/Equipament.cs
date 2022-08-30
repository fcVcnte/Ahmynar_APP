using Ahmynar_Domain.Common;
using Ahmynar_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Domain
{
    public class Equipament : BaseDomainEntity
    {
        public TypeEquipament TypeEquipament { get; set; }
        public string Description { get; set; }
        public string? Specs { get; set; }
        public string? Acessories { get; set; }
        public string? Obs { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
