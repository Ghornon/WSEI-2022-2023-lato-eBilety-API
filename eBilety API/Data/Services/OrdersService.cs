using eBilety.Models;
using Microsoft.EntityFrameworkCore;

namespace eBilety.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;
        private readonly IShoppingCartService _shoppingCartService;
        public OrdersService(AppDbContext context, IShoppingCartService shoppingCartService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems)
                .ThenInclude(n => n.Movie).ThenInclude(n => n.Cinema)
                .Include(n => n.OrderItems)
                .ThenInclude(n => n.Movie).ThenInclude(n => n.Producer)
                .Include(n => n.User).ToListAsync();

            if(userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId)
        {
            var order = new Order()
            {
                UserId = userId
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
                await _shoppingCartService.Delete(item.Id);
            }
            await _context.SaveChangesAsync();
        }
    }
}
