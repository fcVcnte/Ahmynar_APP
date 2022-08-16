using System.ComponentModel.DataAnnotations;

namespace Ahmynar_Domain.Enums
{
    public enum GroupProduct
    {
        [Display(Name = "Computadores")] Computers = 1,
        [Display(Name = "Peças de Computador")] ComputerHards = 2,
        [Display(Name = "Periféricos de Computador")] ComputerPeripherals = 3,
        [Display(Name = "Impressoras")] Printers = 4,
        [Display(Name = "Acessórios de Impressora")] PrinterAcessories = 5
    }
}
