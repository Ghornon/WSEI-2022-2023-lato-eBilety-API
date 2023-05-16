using eBilety.Data.Services;
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
        private readonly IMoviesService _moviesService;
        private readonly IOrdersService _ordersService;

        public OrdersController(IMoviesService moviesService, IOrdersService ordersService)
        {
            _moviesService = moviesService;
            _ordersService = ordersService;
        }

        [HttpGet]
        [Route("api/Orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return Ok(orders);
        }

        [HttpPost("api/ShoppingCart/CompleteOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CompleteOrder()
        {
            /*var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();*/

            //var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return Ok();
        }
    }
}