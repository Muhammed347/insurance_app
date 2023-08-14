using deneme1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace deneme1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaskoController : ControllerBase
    {
        private readonly PersonContext _dbContext;

        public KaskoController(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kasko>>> GetKaskos()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            return await _dbContext.Kaskos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kasko>> GetKasko(int id)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var kasko = await _dbContext.Kaskos.FindAsync(id);

            if (kasko == null)
            {
                return NotFound();
            }

            return kasko;
        }

        [HttpPost]
        public async Task<ActionResult<Kasko>> PostKasko(Kasko kasko)
        {
            _dbContext.Kaskos.Add(kasko);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetKasko), new { id = kasko.KaskoId }, kasko);

        }







        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKasko(int id)
        {
            if (_dbContext.Kaskos == null)
            {
                return NotFound();
            }
            var kasko = await _dbContext.Kaskos.FindAsync(id);
            if (kasko == null)
            {
                return NotFound();

            }
            _dbContext.Kaskos.Remove(kasko);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {

            }
        }
    }
}
