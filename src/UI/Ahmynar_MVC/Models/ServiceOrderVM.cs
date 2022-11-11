using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmynar_MVC.Models
{
    public class ServiceOrderVM : CreateServiceOrderVM
    {
        public int Id { get; set; }
        public BudgetVM Budget { get; set; }
    }

    public class CreateServiceOrderVM
    {
        [Required]
        [Display(Name = "Número da OS")]
        public long Number { get; set; }

        [Display(Name = "Data de Vencimento")]
        public DateTime? DepartureDate { get; set; }
        public Ahmynar_Domain.Enums.StatusDescription Status { get; set; }

        [Required]
        [Display(Name = "Valor total de Descontos")]
        public float? TotalDiscounts { get; set; }

        [Required]
        [Display(Name = "Valor total")]
        public float Total { get; set; }

        [Display(Name = "Observações")]
        public string? Obs { get; set; }

        [Required]
        [Display(Name = "Número do Orçamento")]
        public int BudgetId { get; set; }
        public SelectList Budgets { get; set; }
    }
}
