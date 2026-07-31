
using enterprise_ecommerce.Domain.Entities;
using enterpriseecommerce.Application.Features.Products.Commands.CreateProduct;
using enterpriseecommerce.Application.Features.Products.Queries.GetAllProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enterprise_ecommerce_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductHandler productHandler;
        private readonly GetAllProductsHandler productsHandler;

        public ProductsController(CreateProductHandler productHandler , GetAllProductsHandler productsHandler)
        {
            this.productHandler = productHandler;
            this.productsHandler = productsHandler;
        }

        // GET: api/Products

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await productsHandler.Handle());
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
   
            var productId = await  productHandler.Handle(command);
            return Ok(productId);

        }
        //// PUT: api/Products/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, Product request)
        //{
        //    if (id != request.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var updatedProduct = await _productService.UpdateAsync(id, request);
        //    if (updatedProduct == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(updatedProduct);





        //}

        //// DELETE: api/Products/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    var deleted = await _productService.DeleteAsync(id);
        //    if (!deleted)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(deleted);
        //}

        //// GET: api/Products/{id}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetProduct(int id)
        //{
        //    var product = await _productService.GetByIdAsync(id);
        //    return Ok(product);
        //}
    }
}
