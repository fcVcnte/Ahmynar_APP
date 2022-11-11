using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Sale
{
    public class CreateSaleBudgetDto : ISaleBudgetDto
    {
        public Ahmynar_Domain.Enums.TypeSale TypeSale { get; set; }
        public Ahmynar_Domain.Enums.PaymentSale PaymentSale { get; set; }
        public int? InstallmentPayment { get; set; }
        public float TotalSale { get; set; }
        public string? Obs { get; set; }
        public int BudgetId { get; set; }
    }
}
