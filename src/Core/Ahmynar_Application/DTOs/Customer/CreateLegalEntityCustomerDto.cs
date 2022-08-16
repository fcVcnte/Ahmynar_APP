using Ahmynar_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Customer
{
    public class CreateLegalEntityCustomerDto : ILegalEntityCustomerDto
    {
        public TypeCustomer TypeCustomer { get; set; }
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public string Cnpj { get; set; }
        public string? IE { get; set; }
        public string? IM { get; set; }
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
