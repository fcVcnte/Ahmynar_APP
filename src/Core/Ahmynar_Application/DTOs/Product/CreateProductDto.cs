using Ahmynar_Application.DTOs.Supplier;

namespace Ahmynar_Application.DTOs.Product
{
    public class CreateProductDto : IProductDto
    {
        public string Description { get; set; } = default!;
        public Ahmynar_Domain.Enums.GroupProduct GroupProduct { get; set; }
        public float PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public string? Unit { get; set; }
        public float SalePrice { get; set; }
        public string? Obs { get; set; }
        public int? SupplierId { get; set; }
    }
}
