using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmynar_MVC.Models
{
    public class EquipamentVM : CreateEquipamentVM
    {
        public int Id { get; set; }
        public CustomerVM Customer { get; set; }
    }

    public class CreateEquipamentVM
    {
        [Required]
        [Display(Name = "Tipo")]
        public Ahmynar_Domain.Enums.TypeEquipament TypeEquipament { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Especificações")]
        public string? Specs { get; set; }

        [Display(Name = "Acessórios")]
        public string? Acessories { get; set; }

        [Display(Name = "Observações")]
        public string? Obs { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public SelectList Customers { get; set; }
    }
}
