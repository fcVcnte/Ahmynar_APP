using Ahmynar_Application.DTOs.Common;
using Ahmynar_Domain.Enums;

namespace Ahmynar_Application.DTOs.Customer
{
    public class NaturalPersonCustomerDto : CustomerDto
    {
        public TypeCustomer TypeCustomer { get; set; }
        public string CustomerName { get; set; }
        public string Cpf { get; set; }
        public string? Rg { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
