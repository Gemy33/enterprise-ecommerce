using enterprise_ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enterpriseecommerce.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);

        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<Product?> UpdateAsync(int id, Product product);

        Task<bool> DeleteAsync(int id);
    }
}
