using eBilety.Data.Base;
using eBilety.Models;

namespace eBilety.Data.Services
{
    public class ShoppingCartService : EntityBaseRepository<ShoppingCartItem>, IShoppingCartService
    {
        public ShoppingCartService(AppDbContext context) : base(context)
        {
        }
    }
}
