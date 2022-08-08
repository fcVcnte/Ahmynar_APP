using Ahmynar_Application.DTOs.Common;

namespace Ahmynar_Application.DTOs.Supplier
{
    public class SupplierListDto : BaseDto
    {
        public string TradeName { get; set; }
        public string Cnpj { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
    }
}
