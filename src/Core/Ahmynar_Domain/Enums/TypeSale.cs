using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Domain.Enums
{
    public enum TypeSale
    {
        [Display(Name = "Venda Orçamento")] BudgetSale = 1, //Budget Sale
        [Display(Name = "Venda Rápida")] ProductSale = 2 //Product Sale
    }
}
