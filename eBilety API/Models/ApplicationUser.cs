using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eBilety.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Imię i nazwisko")]
        public string FullName { get; set; }
    }
}
