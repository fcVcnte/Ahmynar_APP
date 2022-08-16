using System.ComponentModel.DataAnnotations;

namespace Ahmynar_Domain.Enums
{
    public enum TypeCustomer
    {
        [Display(Name = "Cliente Jurídico")] LegalEntity = 1, //Legal Entity
        [Display(Name = "Cliente Físico")] NaturalPerson = 2 //Natural Person
    }
}