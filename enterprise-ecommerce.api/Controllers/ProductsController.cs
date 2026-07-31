
using enterprise_ecommerce.Domain.Entities;
using enterpriseecommerce.Application.Features.Products.Commands.CreateProduct;
using enterpriseecommerce.Application.Features.Products.Commands.DeleteProduct;
using enterpriseecommerce.Application.Features.Products.Commands.UpdateProduct;
using enterpriseecommerce.Application.Features.Products.Queries.GetAllProducts;
using enterpriseecommerce.Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enterprise_ecommerce_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/Products

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {

            var productId = await _mediator.Send(command);
            return Ok(productId);

        }
        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductCommand updateProduct)
        {
           var command = new UpdateProductCommand
            {
                ProductId = id,
                ProductName = updateProduct.ProductName,
                ProductDescription = updateProduct.ProductDescription,
                ProductPrice = updateProduct.ProductPrice,
                ProductQuantity = updateProduct.ProductQuantity
            };
            
                await _mediator.Send(command);
                return NoContent();
           



        }

        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _mediator.Send(new DeleteProductCommand(id));
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting product: {ex.Message}");
            }
        }

        //GET: api/Products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var porduct = await _mediator.Send(new GetProductByIdQuery(id));
                return Ok(porduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving product: {ex.Message}");
            }
        }
    }
}
