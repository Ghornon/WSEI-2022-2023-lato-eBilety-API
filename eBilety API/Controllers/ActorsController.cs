using AutoMapper;
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
    [Authorize(Roles = UserRoles.Admin)]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ActorsController : ControllerBase
    {
        private readonly IActorsService _service;
        private readonly IMapper _mapper;
        public ActorsController(IMapper mapper, IActorsService service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ApplicationUser>))]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApplicationUser))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ActorDto actorDto)
        {
            Actor actor = _mapper.Map<Actor>(actorDto);

            if (ModelState.IsValid)
            {
                var newActor = await _service.Add(actor);
                return Created(nameof(Actor), newActor);
            }

            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Actor), StatusCodes.Status200OK, Type = typeof(ApplicationUser))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetById(id);

            return actorDetails == null ? NotFound() : Ok(actorDetails);
                
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationUser))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, ActorDto actorDto)
        {
            var actorDetails = await _service.GetById(id);

            Actor actor = _mapper.Map<Actor>(actorDto);
            actor.Id = id;

            if (actorDetails == null)
                return NotFound();


            if (ModelState.IsValid)
            {
                var updatetedActor = await _service.Update(id, actor);
                return Ok(updatetedActor);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationUser))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
                return NotFound();

            var deletedActor = await _service.Delete(id);

            return Ok(deletedActor);
        }
    }
}
