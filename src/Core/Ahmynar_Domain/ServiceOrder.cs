using Ahmynar_Domain.Common;
using Ahmynar_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Domain
{
    public class ServiceOrder : BaseDomainEntity
    {
        public long Number { get; set; }
        public DateTime? DepartureDate { get; set; }
        public StatusDescription Status { get; set; }
        public float Total { get; set; }
        public string? Obs { get; set; }
        public int BudgetId { get; set; }

        public virtual Budget Budget { get; set; }
    }
}
