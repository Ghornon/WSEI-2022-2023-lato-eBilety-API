using System.ComponentModel.DataAnnotations;

namespace eBilety.Data.ViewModels
{
    public class ShoppingCartItemVM
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        [Range(1, 99)]
        public int Amount { get; set; }
    }
}
