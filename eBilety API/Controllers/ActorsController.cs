using eBilety.Data.Services;
using eBilety.Data.Static;
using eBilety.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace eBilety.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Roles = UserRoles.Admin)]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ActorsController : ControllerBase
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            this._service = service;
        }
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Actor actor)
        {
            if(ModelState.IsValid)
            {
                _service.Add(actor);
                return Created(nameof(Actor), actor);
            }

            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Actor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetById(id);

            return actorDetails == null ? NotFound() : Ok(actorDetails);
                
        }

        /*
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
                return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
                return View(actor);

            await _service.Update(id, actor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null) return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        */
    }
}
