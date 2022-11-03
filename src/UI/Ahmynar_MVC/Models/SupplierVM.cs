using System.ComponentModel.DataAnnotations;

namespace Ahmynar_MVC.Models
{
    public class SupplierVM : CreateSupplierVM
    {
        public int Id { get; set; }
    }

    public class CreateSupplierVM
    {
        [Required]
        [Display(Name = "Nome Empresa")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Nome Fantasia")]
        public string TradeName { get; set; }

        [Required]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Required]
        [Display(Name = "Inscrição Estadual")]
        public string IE { get; set; }

        [Required]
        [Display(Name = "Celular")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Número")]
        public ushort Number { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        public string Address2 { get; set; }

        [Display(Name = "Complemento")]
        public string? AddressComplement { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string State { get; set; }

        [Required]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required]
        [Display(Name = "País")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Site")]
        public string? Website { get; set; }

        [Display(Name = "Observações")]
        public string? Obs { get; set; }
    }
}
