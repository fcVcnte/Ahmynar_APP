using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Domain.Enums
{
    public enum TypeEquipament
    {
        [Display(Name = "Computador")] Computer = 1,
        [Display(Name = "Impressora")] Printer = 2
    }
}
