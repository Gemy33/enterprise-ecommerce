using enterprise_ecommerce_api.Data;
using enterprise_ecommerce_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enterprise_ecommerce_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ProductsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Products

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await dbContext.Products.ToListAsync();
            return Ok(products);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return Ok(product);
        }
        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            var existingProduct = await dbContext.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = request.Name;
            existingProduct.Description = request.Description;
            existingProduct.Price = request.Price;
            existingProduct.Stock = request.Stock;

            await dbContext.SaveChangesAsync();
            return Ok(existingProduct);
        }

        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await dbContext.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            dbContext.Products.Remove(existingProduct);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/Products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
