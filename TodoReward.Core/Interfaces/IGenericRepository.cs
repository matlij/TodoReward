using System.Linq.Expressions;
using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetBySpecificationAsync(Expression<Func<T, bool>> predicate);
        Task<bool> UpdateAsync(Guid id, T item);
    }
}
