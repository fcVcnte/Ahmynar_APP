using Ahmynar_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Customer
{
    public class CustomerListDto
    {
        public TypeCustomer TypeCustomer { get; set; }
        public string? TradeName { get; set; }
        public string? CustomerName { get; set; }
        public string? Phone { get; set; }
        public string? Cellphone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
