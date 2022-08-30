using Ahmynar_Domain.Common;
using Ahmynar_Domain.Enums;

namespace Ahmynar_Domain
{
    public class Customer : BaseDomainEntity
    {
        public TypeCustomer TypeCustomer { get; set; }
        public string? CompanyName { get; set; } //NULL Legal Entity
        public string? TradeName { get; set; } //NULL Legal Entity
        public string? Cnpj { get; set; } //NULL Legal Entity
        public string? IE { get; set; } //NULL Legal Entity
        public string? IM { get; set; } //NULL Legal Entity
        public string? CustomerName { get; set; } //NULL Natural Person
        public string? Cpf { get; set; } //NULL Natural Person
        public string? Rg { get; set; } //NULL Natural Person
        public DateTime? BirthDate { get; set; } //NULL Natural Person
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

        public virtual ICollection<Budget>? Budgets { get; set; }

        public virtual ICollection<Equipament>? Equipaments { get; set; }
    }
}
