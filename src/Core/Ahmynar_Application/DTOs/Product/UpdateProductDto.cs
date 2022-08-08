using Ahmynar_Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Product
{
    public class UpdateProductDto : BaseDto, IProductDto
    {
        public string Description { get; set; } = default!;
        public Ahmynar_Domain.Enums.GroupProduct GroupProduct { get; set; }
        public float PurchasePrice { get; set; }
        public ushort Quantity { get; set; }
        public string? Unit { get; set; }
        public float SalePrice { get; set; }
        public string? Obs { get; set; }
        public int? SupplierId { get; set; }
    }
}
