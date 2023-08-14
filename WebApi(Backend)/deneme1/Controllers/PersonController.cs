using deneme1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace deneme1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _dbContext;

        public PersonController(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            return await _dbContext.Persons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var person = await _dbContext.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _dbContext.Persons.Add(person);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPerson), new { id = person.PersonId }, person);

        }




        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {

            if (id != person.PersonId)
            {
                return BadRequest();
            }
            _dbContext.Entry(person).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (_dbContext.Persons == null)
            {
                return NotFound();
            }
            var person = await _dbContext.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();

            }
            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {

            }
        }
        private bool PersonExists(long id)
        {
            return (_dbContext.Persons?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }

    }
}
