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
    public class ProducersController : ControllerBase
    {
        private readonly IProducersService _service;
        private readonly IMapper _mapper;

        public ProducersController(IMapper mapper, IProducersService service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Producer>))]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAll();
            return Ok(allProducers);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Actor), StatusCodes.Status200OK, Type = typeof(Producer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetById(id);
            return producerDetails == null ? NotFound() : Ok(producerDetails);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Producer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ProducerDto producerDto)
        {
            Producer producer = _mapper.Map<Producer>(producerDto);

            if (ModelState.IsValid)
            {
                var newProducer = await _service.Add(producer);
                return Created(nameof(Producer), newProducer);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Producer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, ProducerDto producerDto)
        {
            var producerDetails = await _service.GetById(id);

            Producer producer = _mapper.Map<Producer>(producerDto);
            producer.Id = id;

            if (producerDetails == null)
                return NotFound();


            if (ModelState.IsValid)
            {
                var updatedProducer = await _service.Update(id, producer);
                return Ok(updatedProducer);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Producer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails == null)
                return NotFound();

            var deletedProducer = await _service.Delete(id);

            return Ok(deletedProducer);
        }
    }
}
