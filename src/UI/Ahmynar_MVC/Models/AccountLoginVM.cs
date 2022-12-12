using System.ComponentModel.DataAnnotations;

namespace Ahmynar_MVC.Models
{
    public class AccountLoginVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
