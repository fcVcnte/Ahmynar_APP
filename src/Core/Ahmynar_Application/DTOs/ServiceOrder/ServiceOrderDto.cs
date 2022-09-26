using Ahmynar_Application.DTOs.Budget;
using Ahmynar_Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.ServiceOrder
{
    public class ServiceOrderDto : BaseDto
    {
        public long Number { get; set; }
        public DateTime? DepartureDate { get; set; }
        public Ahmynar_Domain.Enums.StatusDescription Status { get; set; }
        public float? TotalDiscounts { get; set; }
        public float Total { get; set; }
        public string? Obs { get; set; }
        public int BudgetId { get; set; }

        public BudgetDto Budget { get; set; }
    }
}
