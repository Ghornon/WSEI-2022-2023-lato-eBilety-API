using eBilety.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eBilety.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Avatar")]
        [Required(ErrorMessage = "Zdjęcie profilowe jest wymagane")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Imię i nazwisko")]
        [Required(ErrorMessage = "Imię i nazwisko jest wymagane")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Imię i nazwisko musi mieć od 5 do 50 znaków")]
        public string FullName { get; set; }
        [Display(Name = "Biografia")]
        [Required(ErrorMessage = "Biografia jest wymagana")]
        public string Bio { get; set; }
        public List<ActorMovie>? ActorsMovies { get; set; }

    }
}
