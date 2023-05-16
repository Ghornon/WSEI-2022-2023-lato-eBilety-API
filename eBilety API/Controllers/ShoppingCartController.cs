using AutoMapper;
using eBilety.Data.Services;
using eBilety.Data.ViewModels;
using eBilety.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace eBilety.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _service;
        private readonly IMapper _mapper;

        public ShoppingCartController(IMapper mapper, IShoppingCartService service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Index()
        {
            var allItems = await _service.GetAll(n => n.User);
            return Ok(allItems);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ShoppingCartItemVM shoppingCartItemVM)
        {
            ShoppingCartItem shoppingCartItem = _mapper.Map<ShoppingCartItem>(shoppingCartItemVM);

            /*var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            shoppingCartItem.UserId = userId;*/

            var userId = User.Identity.Name();
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("userId");
            Console.WriteLine(userId);
            Console.WriteLine(userRole);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");

            if (ModelState.IsValid)
            {
                var newShoppingCartItem = await _service.Add(shoppingCartItem);
                return Created(nameof(ShoppingCartItem), newShoppingCartItem);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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


            if (ModelState.IsValid)
            {
                var updatedShoppingCartItem = await _service.Update(id, shoppingCartItem);
                return Ok(updatedShoppingCartItem);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var shoppingCartItemDetails = await _service.GetById(id);
            if (shoppingCartItemDetails == null)
                return NotFound();

            var deletedShoppingCartItem= await _service.Delete(id);

            return Ok(deletedShoppingCartItem);
        }
    }
}
