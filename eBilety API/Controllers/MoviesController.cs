using eBilety.Data;
using eBilety.Data.Services;
using eBilety.Data.Static;
using eBilety.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = UserRoles.Admin)]
    [Produces("application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Movie>))]
        public async Task<IActionResult> Index([FromQuery] string? searchString)
        {
            var allMovies = await _service.GetAll(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return filteredResultNew.Count == 0 ? NotFound() : Ok(filteredResultNew);
            }

            return Ok(allMovies);
        }

        //GET: Movies/Details/1
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return movieDetail == null ? NotFound() : Ok(movieDetail);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (ModelState.IsValid)
            {
                Movie newMovie = await _service.AddNewMovieAsync(movie);

                return Created(nameof(Movie), newMovie);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            var movieDetails = await _service.GetById(id);

            movieDetails.Id = id;

            if (movieDetails == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                Movie updatetedMovie = await _service.UpdateMovieAsync(movie);
                return Ok(updatetedMovie);
            }

            return BadRequest(ModelState);
        }


    }
}