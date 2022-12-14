using Ahmynar_Domain.Common;

namespace Ahmynar_Domain
{
    public class Supplier : BaseDomainEntity
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

        public virtual ICollection<Product>? Products { get; set; }
    }
}
