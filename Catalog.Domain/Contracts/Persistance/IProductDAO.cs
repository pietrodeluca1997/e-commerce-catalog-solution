using Catalog.Domain.Entities;

namespace Catalog.Domain.Contracts.Persistance
{
    public interface IProductDAO
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> GetByIdAsync(int productId);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync(Product product);

    }
}
