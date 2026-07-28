using enterprise_ecommerce_api.Models;

namespace enterprise_ecommerce_api.Services.Interfaces
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
