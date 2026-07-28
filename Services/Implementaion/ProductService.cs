using enterprise_ecommerce_api.Data;
using enterprise_ecommerce_api.Models;
using enterprise_ecommerce_api.Repositories.Interfaces;
using enterprise_ecommerce_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace enterprise_ecommerce_api.Services.Implementaion
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _db;

        public ProductService(IProductRepository db)
        {
            _db = db;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            return await _db.AddAsync(product);
            
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _db.GetByIdAsync(id);
        }

        public async Task<Product?> UpdateAsync(int id, Product request)
        {
            var product = await _db.GetByIdAsync(id);

            if (product == null)
                return null;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Stock = request.Stock;

            await _db.UpdateAsync(product);

            return product;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _db.GetByIdAsync(id);
            if (product == null)
                return false;
            await _db.DeleteAsync(product);

            return true;

        }
    }
}
