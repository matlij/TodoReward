using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{

    public interface IGenericRepository<T> : IGenericReadonlyRepository<T> 
        where T : BaseEntity
    {
        Task<bool> AddAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<bool> UpdateAsync(string id, T item);
        Task<bool> UpdateRangeAsync(IEnumerable<T> items);
    }
}
