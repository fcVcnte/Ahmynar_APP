using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Domain.Enums
{
    public enum PaymentSale
    {
        [Display(Name = "Débito")] Debit = 1,
        [Display(Name = "Crédito")] Credit = 2,
        [Display(Name = "Crédito com Parcelas")] Installment = 3,
        [Display(Name = "Boleto")] Boleto = 4,
        [Display(Name = "Pix")] Pix = 5,
        [Display(Name = "Cheque")] Check = 6
    }
}
