using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmynar_MVC.Models
{
    public class SaleVM : CreateSaleVM
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public List<ProductVM> Products { get; set; }
        public BudgetVM Budget { get; set; }
    }

    public class CreateSaleVM
    {
        [Required]
        [Display(Name = "Tipo da Venda")]
        public Ahmynar_Domain.Enums.TypeSale TypeSale { get; set; }

        [Required]
        [Display(Name = "Meio de Pagamento")]
        public Ahmynar_Domain.Enums.PaymentSale PaymentSale { get; set; }

        [Display(Name = "Parcelas")]
        public int? InstallmentPayment { get; set; }

        [Required]
        [Display(Name = "Valor descontos")]
        public float? TotalDiscounts { get; set; }

        [Required]
        [Display(Name = "Valor total")]
        public float TotalSale { get; set; }

        [Display(Name = "Observações")]
        public string? Obs { get; set; }

        [Display(Name = "Número do Orçamento")]
        public int? BudgetId { get; set; }
        public SelectList? Budgets { get; set; }

        [Display(Name = "Produtos")]
        public List<int>? ProductIds { get; set; }
        public SelectList? ProductsList { get; set; }
    }
}
