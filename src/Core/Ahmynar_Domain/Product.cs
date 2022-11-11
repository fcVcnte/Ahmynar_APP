using Ahmynar_Domain.Common;
using Ahmynar_Domain.Enums;

namespace Ahmynar_Domain
{
    public class Product : BaseDomainEntity
    {
        public string Description { get; set; }
        public GroupProduct GroupProduct { get; set; }
        public float PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public string? Unit { get; set; }
        public float SalePrice { get; set; }
        public string? Obs { get; set; }
        public int? SupplierId { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<Budget>? Budgets { get; set; }
        public virtual ICollection<Sale>? Sales { get; set; }
    }
}
