using deneme1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace deneme1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficController : ControllerBase
    {
        private readonly PersonContext _dbContext;

        public TrafficController(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Traffic>>> GetTraffics()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            return await _dbContext.Traffics.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Traffic>> GetTraffic(int id)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var person = await _dbContext.Traffics.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public async Task<ActionResult<Traffic>> PostTraffic(Traffic traffic)
        {
            _dbContext.Traffics.Add(traffic);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTraffic), new { id = traffic.TrafficId }, traffic);

        }




        


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraffic(int id)
        {
            if (_dbContext.Traffics == null)
            {
                return NotFound();
            }
            var traffic = await _dbContext.Traffics.FindAsync(id);
            if (traffic == null)
            {
                return NotFound();

            }
            _dbContext.Traffics.Remove(traffic);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {

            }
        }
        


    }
}
