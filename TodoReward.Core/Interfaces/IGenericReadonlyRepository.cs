using System.Linq.Expressions;
using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface IGenericReadonlyRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetBySpecificationAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetBySpecificationAsync(string filter);
    }
}
