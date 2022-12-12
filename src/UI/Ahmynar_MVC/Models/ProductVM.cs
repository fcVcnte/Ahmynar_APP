using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmynar_MVC.Models
{
    public class ProductVM : CreateProductVM
    {
        public int Id { get; set; }

        public SupplierVM? Supplier { get; set; }
    }

    public class CreateProductVM
    {
        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Grupo do Produto")]
        public Ahmynar_Domain.Enums.GroupProduct GroupProduct { get; set; }

        [Required]
        [Display(Name = "Preço de Compra")]
        public float PurchasePrice { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public int Quantity { get; set; }

        [Display(Name = "Unidade")]
        public string? Unit { get; set; }

        [Required]
        [Display(Name = "Preço de Venda")]
        public float SalePrice { get; set; }

        [Display(Name = "Observações")]
        public string? Obs { get; set; }

        [Display(Name = "Fornecedor")]
        public int? SupplierId { get; set; }

        public SelectList Suppliers { get; set; }

        public string DescSale 
        {
            get { return Description + " | [R$" + SalePrice + "] "; }
        }
    }
}
