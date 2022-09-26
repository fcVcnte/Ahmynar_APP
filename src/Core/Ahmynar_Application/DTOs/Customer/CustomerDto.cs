using Ahmynar_Application.DTOs.Budget;
using Ahmynar_Application.DTOs.Common;
using Ahmynar_Application.DTOs.Equipament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Customer
{
    public class CustomerDto : BaseDto
    {
        public string? Phone { get; set; }
        public string? Cellphone { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Address2 { get; set; }
        public string? AddressComplement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string? Obs { get; set; }

        public List<BudgetDto>? Budgets { get; set; }
        public List<EquipamentDto>? Equipaments { get; set; }
    }
}
