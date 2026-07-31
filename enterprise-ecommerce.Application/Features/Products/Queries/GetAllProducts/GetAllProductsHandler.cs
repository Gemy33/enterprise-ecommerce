using enterpriseecommerce.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enterpriseecommerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler
{
        private readonly IProductRepository _repository;
        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAllProductsQuery>> Handle()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => new GetAllProductsQuery
            {
                ProductId = p.Id,
                ProductName = p.Name,
                ProductDescription = p.Description,
                ProductPrice = p.Price,
                ProductQuantity = p.Stock
            }).ToList();
        }
    }
}
