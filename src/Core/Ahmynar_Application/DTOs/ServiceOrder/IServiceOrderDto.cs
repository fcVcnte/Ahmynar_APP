using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.ServiceOrder
{
    public interface IServiceOrderDto
    {
        public long Number { get; set; }
        public DateTime? DepartureDate { get; set; }
        public Ahmynar_Domain.Enums.StatusDescription Status { get; set; }
        public float? TotalDiscounts { get; set; }
        public float Total { get; set; }
        public string? Obs { get; set; }
        public int BudgetId { get; set; }
    }
}
