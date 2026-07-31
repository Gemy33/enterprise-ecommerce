using enterpriseecommerce.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enterpriseecommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new Exception($"Product with ID {request.ProductId} not found.");
            }
            product.Name = request.ProductName;
            product.Description = request.ProductDescription;
            product.Price = request.ProductPrice;
            product.Stock = request.ProductQuantity;

            await productRepository.UpdateAsync(product);
            return;

        }
    }
}
