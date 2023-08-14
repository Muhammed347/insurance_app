using deneme1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace deneme1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaskController : ControllerBase
    {
        private readonly PersonContext _dbContext;

        public DaskController(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dask>>> GetDasks()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            return await _dbContext.Dasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dask>> GetDask(int id)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var dask = await _dbContext.Dasks.FindAsync(id);

            if (dask == null)
            {
                return NotFound();
            }

            return dask;
        }

        [HttpPost]
        public async Task<ActionResult<Dask>> PostDask(Dask dask)
        {
            _dbContext.Dasks.Add(dask);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDask), new { id = dask.DaskId }, dask);

        }



        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDask(int id, Dask Dask)
        {

            if (id != Dask.DaskId)
            {
                return BadRequest();
            }
            _dbContext.Entry(Dask).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)
            {
                if (!DaskExists(id))
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
        public async Task<IActionResult> DeleteDask(int id)
        {
            if (_dbContext.Dasks == null)
            {
                return NotFound();
            }
            var Dask = await _dbContext.Dasks.FindAsync(id);
            if (Dask == null)
            {
                return NotFound();

            }
            _dbContext.Dasks.Remove(Dask);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {

            }
        }
        private bool DaskExists(long id)
        {
            return (_dbContext.Dasks?.Any(e => e.DaskId == id)).GetValueOrDefault();
        }
    }
}
