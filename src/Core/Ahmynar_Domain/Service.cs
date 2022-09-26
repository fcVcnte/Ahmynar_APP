using Ahmynar_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Domain
{
    public class Service : BaseDomainEntity
    {
        public string Description { get; set; }
        public float SalePrice { get; set; }
        public string? Obs { get; set; }

        public virtual ICollection<Budget>? Budgets { get; set; }
    }
}
