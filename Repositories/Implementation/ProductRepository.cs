using enterprise_ecommerce_api.Data;
using enterprise_ecommerce_api.Models;
using enterprise_ecommerce_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace enterprise_ecommerce_api.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Product> AddAsync(Product product)
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

        public async Task<Product?> UpdateAsync(Product product)
        {
            _db.Products.Update(product);

            await _db.SaveChangesAsync();

            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _db.Products.Remove(product);

            await _db.SaveChangesAsync();
        }
    }
}
