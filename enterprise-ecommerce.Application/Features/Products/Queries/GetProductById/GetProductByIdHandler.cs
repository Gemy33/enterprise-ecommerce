using enterpriseecommerce.Application.DTO_s.Product;
using enterpriseecommerce.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enterpriseecommerce.Application.Features.Products.Queries.GetProductById
{
    internal class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            
            var product =await _productRepository.GetAllAsync(pro => pro.Id == request.Id);
            var productDto = product.Select(pro => new ProductDto
            {
                Id = pro.Id,
                Name = pro.Name,
                Description = pro.Description,
                Price = pro.Price,
                Stock = pro.Stock
            }).FirstOrDefault();

            return productDto ?? throw new Exception("Product not found");
        }
    }
}
