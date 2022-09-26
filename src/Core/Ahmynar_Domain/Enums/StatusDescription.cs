using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Domain.Enums
{
    public enum StatusDescription
    {
        [Display(Name = "Aberto")] Open = 1,
        [Display(Name = "Na Fila")] InQueue = 2,
        [Display(Name = "Em Processo")] InProcess = 3,
        [Display(Name = "Finalizado")] Finished = 4,
        [Display(Name = "Cancelado")] Canceled = 5
    }
}
