using System.ComponentModel.DataAnnotations;

namespace Ahmynar_MVC.Models
{
    public class CustomerVM : CreateCustomerVM
    {
        public int Id { get; set; }
    }

    public class CreateCustomerVM
    {
        [Required]
        [Display(Name = "Tipo do Cliente")]
        public Ahmynar_Domain.Enums.TypeCustomer TypeCustomer { get; set; }

        [Display(Name = "Razão Social")]
        public string? CompanyName { get; set; }

        [Display(Name = "Nome Empresarial")]
        public string? TradeName { get; set; }

        [Display(Name = "CNPJ")]
        public string? Cnpj { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string? IE { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string? IM { get; set; }

        [Display(Name = "Nome Físico")]
        public string? CustomerName { get; set; }

        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        [Display(Name = "RG")]
        public string? Rg { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Telefone")]
        public string? Phone { get; set; }

        [Display(Name = "Celular")]
        public string? Cellphone { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Número")]
        public int Number { get; set; }

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
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Observações")]
        public string? Obs { get; set; }
    }
}
