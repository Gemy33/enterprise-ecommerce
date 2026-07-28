using enterprise_ecommerce_api.Data;
using enterprise_ecommerce_api.Models;
using enterprise_ecommerce_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace enterprise_ecommerce_api.Services.Implementaion
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _db.Products.Add(product);

            await _db.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task<Product?> UpdateAsync(int id, Product request)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
                return null;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Stock = request.Stock;

            await _db.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
                return false;

            _db.Products.Remove(product);

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
