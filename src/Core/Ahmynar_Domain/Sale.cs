using Ahmynar_Domain.Common;
using Ahmynar_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Domain
{
    public class Sale : BaseDomainEntity
    {
        public TypeSale TypeSale { get; set; }
        public PaymentSale PaymentSale { get; set; }
        public int? InstallmentPayment { get; set; }
        public float TotalSale { get; set; }
        public string? Obs { get; set; }
        public int? BudgetId { get; set; }

        public virtual Budget? Budget { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
