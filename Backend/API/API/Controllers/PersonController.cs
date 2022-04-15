using API.DTOs;
using AutoMapper;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> Get()
        {
            return Ok(await _personService.GetAllPersonsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> Get(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);

            return person is not null ? Ok(person) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _mapper.Map<Person>(dto);

            await _personService.AddPersonAsync(person);

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonDTO dto)
        {
            var person = await _personService.GetPersonByIdAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            person = _mapper.Map(dto, person);

            await _personService.UpdatePersonAsync(person);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            await _personService.RemovePersonAsync(person);

            return NoContent();
        }
    }
}
