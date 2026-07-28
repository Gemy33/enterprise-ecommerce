using enterprise_ecommerce_api.Data;
using enterprise_ecommerce_api.Models;
using enterprise_ecommerce_api.Services.Implementaion;
using enterprise_ecommerce_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enterprise_ecommerce_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();
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
           
            var createdProduct = await _productService.CreateAsync(product);
            return createdProduct != null ? CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct) : BadRequest();
        


        }
        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var updatedProduct = await _productService.UpdateAsync(id, request);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            return Ok(updatedProduct);





        }

        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }

        // GET: api/Products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
