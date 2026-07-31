using enterprise_ecommerce.Domain.Entities;
using enterpriseecommerce.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enterpriseecommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateProductCommand command)
        {
          var product = new Product
          {
              Name = command.Name,
              Description = command.Description,
              Price = command.Price,
              Stock = command.Stock
          };
            await _repository.AddAsync(product);
            return product.Id;
        }
    }
}
