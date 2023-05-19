using AutoMapper;
using eBilety.Data.Services;
using eBilety.Data.Static;
using eBilety.Data.ViewModels;
using eBilety.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Claims;

namespace eBilety.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = UserRoles.User)]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShoppingCartService _service;
        private readonly IMoviesService _moviesService;

        public ShoppingCartController(IMapper mapper, IShoppingCartService service, IMoviesService moviesService)
        {
            _mapper = mapper;
            _service = service;
            _moviesService = moviesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ShoppingCartItem>))]
        public async Task<IActionResult> GetShoppingCart()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allItems = await _service.GetAll(n => n.Movie, n => n.Movie.Cinema, n => n.Movie.Producer);

            return Ok(allItems.Where(n => n.UserId == userId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ShoppingCartItem))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ShoppingCartItemVM shoppingCartItemVM)
        {
            ShoppingCartItem shoppingCartItem = _mapper.Map<ShoppingCartItem>(shoppingCartItemVM);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            shoppingCartItem.UserId = userId;

            var MovieDetailt = await _moviesService.GetMovieByIdAsync(shoppingCartItemVM.MovieId);

            if (MovieDetailt == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                var newShoppingCartItem = await _service.Add(shoppingCartItem);
                return Created(nameof(ShoppingCartItem), newShoppingCartItem);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(ShoppingCartItem))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, ShoppingCartItemVM shoppingCartItemVM)
        {
            var shoppingCartItemDetails = await _service.GetById(id);

            ShoppingCartItem shoppingCartItem = _mapper.Map<ShoppingCartItem>(shoppingCartItemVM);
            shoppingCartItem.Id = id;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            shoppingCartItem.UserId = userId;

            if (shoppingCartItemDetails == null)
                return NotFound();

            if (ModelState.IsValid && shoppingCartItemDetails.MovieId == shoppingCartItemVM.MovieId)
            {
                var updatedShoppingCartItem = await _service.Update(id, shoppingCartItem);
                return Ok(updatedShoppingCartItem);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShoppingCartItem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var shoppingCartItemDetails = await _service.GetById(id);

            if (shoppingCartItemDetails == null)
                return NotFound();

            var deletedShoppingCartItem = await _service.Delete(id);

            return Ok(deletedShoppingCartItem);
        }
    }
}
