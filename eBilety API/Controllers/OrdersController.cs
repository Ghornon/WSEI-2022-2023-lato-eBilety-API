using eBilety.Data.Services;
using eBilety.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Claims;

namespace eBilety.Controllers
{
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IShoppingCartService _shoppingCartService;

        public OrdersController(IOrdersService ordersService, IShoppingCartService shoppingCartService)
        {
            _ordersService = ordersService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        [Route("api/Orders")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Order>))]
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return Ok(orders);
        }

        [HttpPost("api/CompleteOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CompleteOrder()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allItems = await _shoppingCartService.GetAll(n => n.Movie, n => n.Movie.Cinema, n => n.Movie.Producer);

            var items = allItems.Where(n => n.UserId == userId).ToList();

            if (items.Count == 0)
                return NotFound();

            string userRole = User.FindFirstValue(ClaimTypes.Role);

            await _ordersService.StoreOrderAsync(items, userId);

            return Ok();
        }
    }
}