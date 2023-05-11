using System.ComponentModel.DataAnnotations;

namespace eBilety.Models
{
    public class CinemaDto
    {
        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo jest wymagane")]
        public string Logo { get; set; }

        [Display(Name = "Nazwa kina")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Description { get; set; }
    }
}
