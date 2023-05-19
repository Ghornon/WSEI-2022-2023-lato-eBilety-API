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
    public class CinemasController : ControllerBase
    {
        private readonly ICinemasService _service;
        private readonly IMapper _mapper;
        public CinemasController(IMapper mapper, ICinemasService service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Cinema>))]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAll();
            return Ok(allCinemas);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Cinema))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] CinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            if (ModelState.IsValid)
            {
                var newCinema = await _service.Add(cinema);
                return Created(nameof(Cinema), newCinema);
            }

            return BadRequest(ModelState);
        }

        //Get: Cinemas/Details/1
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Actor), StatusCodes.Status200OK, Type = typeof(Cinema))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetById(id);

            return cinemaDetails == null ? NotFound() : Ok(cinemaDetails); ;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cinema))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, CinemaDto cinemaDto)
        {
            var cinemaDetails = await _service.GetById(id);

            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            cinema.Id = id;

            if (cinemaDetails == null)
                return NotFound();


            if (ModelState.IsValid)
            {
                var updatedCinema = await _service.Update(id, cinema);
                return Ok(updatedCinema);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cinema))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetById(id);
            if (cinemaDetails == null)
                return NotFound();

            var deletedCinema = await _service.Delete(id);

            return Ok(deletedCinema);
        }
    }
}
