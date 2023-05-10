using eBilety.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eBilety.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Avatar")]
        [Required(ErrorMessage = "Avatar jest wymagany")]
        public string Avatar { get; set; }

        [Display(Name = "Imię i nazwisko")]
        [Required(ErrorMessage = "Imię i nazwisko jest wymagane")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Imię i nazwisko musi mieć od 5 do 50 znaków")]
        public string FullName { get; set; }

        [Display(Name = "Biografia")]
        [Required(ErrorMessage = "Biografia jest wymagana")]
        public string Bio { get; set; }

        //Relationships
        public List<Movie>? Movies { get; set; }
    }
}
