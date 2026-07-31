using enterprise_ecommerce.Domain.Entities;
using enterprise_ecommerce.Infrastructure.Persistence;
using enterpriseecommerce.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enterprise_ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            this._db = db;
        }
        public async Task<Product> AddAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _db.Products.Remove(product);
           await  _db.SaveChangesAsync();

        }

        public Task<List<Product>> GetAllAsync(Func<Product, bool>? predicate = null)
        {
            if (predicate == null)
            {
                return _db.Products.ToListAsync();
            }
            else
            {
                return Task.FromResult(_db.Products.Where(predicate).ToList());
            }
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> UpdateAsync(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }
    }
}
