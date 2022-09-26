using Ahmynar_Application.DTOs.Budget;
using Ahmynar_Application.DTOs.Common;
using Ahmynar_Application.DTOs.Supplier;

namespace Ahmynar_Application.DTOs.Product
{
    public class ProductDto : BaseDto
    {
        public string Description { get; set; }
        public Ahmynar_Domain.Enums.GroupProduct GroupProduct { get; set; }
        public float PurchasePrice { get; set; }
        public ushort Quantity { get; set; }
        public string? Unit { get; set; }
        public float SalePrice { get; set; }
        public string? Obs { get; set; }
        public int? SupplierId { get; set; }

        public SupplierDto? Supplier { get; set; }
        public List<BudgetDto>? Budgets { get; set; }
    }
}
