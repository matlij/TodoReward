using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetBySpecificationAsync(Func<T, bool> predicate);
        Task<bool> UpdateAsync(Guid id, T item);
    }
}
