using Ahmynar_Application.DTOs.Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Sale
{
    public class SaleBudgetDto : SaleDto
    {
        public int BudgetId { get; set; }
        public BudgetDto Budget { get; set; }
    }
}
