using deneme1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace deneme1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly PersonContext _dbContext;

        public ProductController(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            return await _dbContext.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);

        }




        


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_dbContext.Products == null)
            {
                return NotFound();
            }
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();

            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {

            }
        }

    }
}
