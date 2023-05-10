using eBilety.Data;
using eBilety.Data.Base;
using eBilety.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eBilety.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa filmu")]
        [Required(ErrorMessage = "Name filmu jest wymagana")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Description { get; set; }

        [Display(Name = "Cena biletu")]
        [Required(ErrorMessage = "Cena biletu jest wymagana")]
        public double Price { get; set; }

        [Display(Name = "Plakat")]
        [Required(ErrorMessage = "Plakat jest wymagany")]
        public string ImageURL { get; set; }

        [Display(Name = "Data rozpoczęcia")]
        [Required(ErrorMessage = "Data rozpoczęcia jest wymagana")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Data zakończenia")]
        [Required(ErrorMessage = "Data zakończenia jest wymagana")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Kategoria filmu jest wymagana")]
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        [Display(Name = "Lista aktorów")]
        [Required(ErrorMessage = "Aktorzy są wymagani")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Kino")]
        [Required(ErrorMessage = "Kino jest wymagane")]
        public int CinemaId { get; set; }

        [Display(Name = "Reżyser")]
        [Required(ErrorMessage = "Reżyser jest wymagany")]
        public int ProducerId { get; set; }
    }
}
