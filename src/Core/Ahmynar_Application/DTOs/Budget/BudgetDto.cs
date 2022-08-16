using Ahmynar_Application.DTOs.Common;
using Ahmynar_Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Budget
{
    public class BudgetDto : BaseDto
    {
        public long Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public float? TotalDiscounts { get; set; }
        public float Total { get; set; }
        public string? Obs { get; set; }
        public int CustomerId { get; set; }

        public virtual CustomerDto Customer { get; set; }
    }
}
