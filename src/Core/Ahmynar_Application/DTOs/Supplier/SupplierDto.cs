using Ahmynar_Application.DTOs.Common;
using Ahmynar_Application.DTOs.Product;
using System.Collections.Generic;

namespace Ahmynar_Application.DTOs.Supplier
{
    public class SupplierDto : BaseDto
    {
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public string Cnpj { get; set; }
        public string IE { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public ushort Number { get; set; }
        public string Address2 { get; set; }
        public string? AddressComplement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string? Website { get; set; }
        public string? Obs { get; set; }

        public ICollection<ProductDto>? Products { get; set; }
    }
}
