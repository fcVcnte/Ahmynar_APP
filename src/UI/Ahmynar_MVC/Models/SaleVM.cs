using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmynar_MVC.Models
{
    public class SaleVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Meio de Pagamento")]
        public Ahmynar_Domain.Enums.PaymentSale PaymentSale { get; set; }

        [Display(Name = "Parcelas")]
        public int? InstallmentPayment { get; set; }

        [Required]
        [Display(Name = "Valor total da Venda")]
        public float TotalSale { get; set; }

        [Required]
        [Display(Name = "Observações")]
        public string? Obs { get; set; }
        public List<ProductVM> Products { get; set; }
        public int BudgetId { get; set; }
        public BudgetVM Budget { get; set; }
    }

    public class CreateSaleBudgetVM
    {
        [Required]
        [Display(Name = "Meio de Pagamento")]
        public Ahmynar_Domain.Enums.PaymentSale PaymentSale { get; set; }

        [Display(Name = "Parcelas")]
        public int? InstallmentPayment { get; set; }

        [Required]
        [Display(Name = "Valor total da Venda")]
        public float TotalSale { get; set; }

        [Required]
        [Display(Name = "Observações")]
        public string? Obs { get; set; }

        [Required]
        [Display(Name = "Número do Orçamento")]
        public int BudgetId { get; set; }
        public SelectList Budgets { get; set; }
    }

    public class CreateSaleProductsVM
    {
        [Required]
        [Display(Name = "Meio de Pagamento")]
        public Ahmynar_Domain.Enums.PaymentSale PaymentSale { get; set; }

        [Display(Name = "Parcelas")]
        public int? InstallmentPayment { get; set; }

        [Required]
        [Display(Name = "Valor total da Venda")]
        public float TotalSale { get; set; }

        [Required]
        [Display(Name = "Observações")]
        public string? Obs { get; set; }

        [Required]
        [Display(Name = "Produtos")]
        public List<int> ProductIds { get; set; }
        public SelectList ProductsList { get; set; }
    }
}
