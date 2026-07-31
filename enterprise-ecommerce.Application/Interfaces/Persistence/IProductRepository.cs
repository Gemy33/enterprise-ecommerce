using enterprise_ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enterpriseecommerce.Application.Interfaces.Persistence
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);

        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<Product?> UpdateAsync(Product product);

        Task DeleteAsync(Product product);
    }
}
