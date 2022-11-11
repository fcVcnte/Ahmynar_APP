using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Sale
{
    public class CreateSaleProductsDto : ISaleProductsDto
    {
        public Ahmynar_Domain.Enums.TypeSale TypeSale { get; set; }
        public Ahmynar_Domain.Enums.PaymentSale PaymentSale { get; set; }
        public int? InstallmentPayment { get; set; }
        public float TotalSale { get; set; }
        public string? Obs { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
