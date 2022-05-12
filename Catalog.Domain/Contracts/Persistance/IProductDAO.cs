using Catalog.Domain.Entities;

namespace Catalog.Domain.Contracts.Persistance
{
    public interface IProductDAO
    {
        Task<bool> CreateAsync(Product product);
        Task<Product> GetByIdAsync(int productId);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(Product product);

    }
}
