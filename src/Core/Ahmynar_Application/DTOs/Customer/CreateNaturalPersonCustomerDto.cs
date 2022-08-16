using Ahmynar_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Customer
{
    public class CreateNaturalPersonCustomerDto : INaturalPersonCustomerDto
    {
        public TypeCustomer TypeCustomer { get; set; }
        public string CustomerName { get; set; }
        public string Cpf { get; set; }
        public string? Rg { get; set; }
        public DateTime? BirthDate { get; set; }
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
    }
}
