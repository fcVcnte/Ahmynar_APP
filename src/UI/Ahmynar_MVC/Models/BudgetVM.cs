using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmynar_MVC.Models
{
    public class BudgetVM : CreateBudgetVM
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public CustomerVM Customer { get; set; }
        public List<ServiceVM> Services { get; set; }
        public List<ProductVM>? Products { get; set; }
    }

    public class CreateBudgetVM
    {
        [Required]
        [Display(Name = "Número")]
        public long Number { get; set; }

        [Required]
        [Display(Name = "Status do Orçamento")]
        public Ahmynar_Domain.Enums.StatusDescription Status { get; set; }

        [Required]
        [Display(Name = "Data de Expiração")]
        public DateTime ExpireDate 
        { 
            get { return expireDate; } 
            set { expireDate = value; } 
        }

        [Display(Name = "Valor total de Serviços")]
        public float? TotalServices { get; set; }

        [Display(Name = "Valor total de Produtos")]
        public float? TotalProducts { get; set; }

        [Required]
        [Display(Name = "Valor total")]
        public float Total { get; set; }

        [Display(Name = "Observações")]
        public string? Obs { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public SelectList Customers { get; set; }

        [Required]
        [Display(Name = "Serviços")]
        public List<int> ServiceIds { get; set; }
        public SelectList ServicesList { get; set; }

        [Display(Name = "Produtos")]
        public List<int>? ProductIds { get; set; }
        public SelectList ProductsList { get; set; }

        private DateTime expireDate = DateTime.Now.Date.AddDays(30);

        public string NumberTotal
        {
            get { return Number.ToString() + " | [R$" + Total.ToString() + "] "; }
        }
    }
}
