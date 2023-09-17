using System.Linq.Expressions;
using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetBySpecificationAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetBySpecificationAsync(string filter);
        Task<bool> UpdateAsync(string id, T item);
        Task<bool> UpdateRangeAsync(IEnumerable<T> items);
    }
}
