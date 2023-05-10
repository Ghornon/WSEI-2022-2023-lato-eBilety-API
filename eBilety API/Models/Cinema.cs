using eBilety.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eBilety.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo jest wymagane")]
        public string Logo { get; set; }

        [Display(Name = "Nazwa kina")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
