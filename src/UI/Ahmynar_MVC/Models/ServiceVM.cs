using System.ComponentModel.DataAnnotations;

namespace Ahmynar_MVC.Models
{
    public class ServiceVM : CreateServiceVM
    {
        public int Id { get; set; }
    }

    public class CreateServiceVM
    {
        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Preço de Venda")]
        public float SalePrice { get; set; }

        [Display(Name = "Observações")]
        public string? Obs { get; set; }

        public string DescSale
        {
            get { return Description + " | [R$" + SalePrice + "] "; }
        }
    }
}
