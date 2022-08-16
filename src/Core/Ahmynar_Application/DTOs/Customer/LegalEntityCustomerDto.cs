using Ahmynar_Application.DTOs.Common;
using Ahmynar_Domain.Enums;

namespace Ahmynar_Application.DTOs.Customer
{
    public class LegalEntityCustomerDto : CustomerDto
    {
        public TypeCustomer TypeCustomer { get; set; }
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public string Cnpj { get; set; }
        public string? IE { get; set; }
        public string? IM { get; set; }
    }
}
