using enterpriseecommerce.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enterpriseecommerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new Exception($"Product with Id {request.Id} not found.");
            }
            await productRepository.DeleteAsync(product!);
            return;

        }
    }
}
