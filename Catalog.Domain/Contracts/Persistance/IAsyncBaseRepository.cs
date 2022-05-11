using System.Linq.Expressions;

namespace Catalog.Domain.Contracts.Persistance
{
    public interface IAsyncBaseRepository<TEntityDocument> where TEntityDocument : IEntityDocument
    {
        Task<IList<TEntityDocument>> ListAllAsync();
        Task<TEntityDocument> GetByIdAsync(string id);
        Task<IList<TEntityDocument>> FilterByAsync(Expression<Func<TEntityDocument, bool>> filterExpression);
        Task CreateAsync(TEntityDocument document);
        Task<bool> UpdateAsync(TEntityDocument document);
        Task<bool> DeleteAsync(string id);
    }
}
