using Ahmynar_Domain.Common;
using Ahmynar_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Domain
{
    public class Budget : BaseDomainEntity
    {
        public long Number { get; set; }
        public StatusDescription Status { get; set; }
        public DateTime ExpireDate { get; set; }
        public float? TotalServices { get; set; }
        public float? TotalProducts { get; set; }
        public float Total { get; set; }
        public string? Obs { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
