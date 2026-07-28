using enterprise_ecommerce_api.Models;

namespace enterprise_ecommerce_api.Repositories.Interfaces
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
