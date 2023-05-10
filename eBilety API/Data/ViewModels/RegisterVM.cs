using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBilety.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Imię i nazwisko")]
        [Required(ErrorMessage = "Imię i nazwisko jest wymagane")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email jest wymagany")]
        public string EmailAddress { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Hasło nie może być puste")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Powtórz hasło")]
        [Required(ErrorMessage = "Hasło nie może być puste")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła nie pasują")]
        public string ConfirmPassword { get; set; }
    }
}
