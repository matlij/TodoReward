using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<bool> AddAsync(TodoItem item);
        Task<IEnumerable<TodoItem>> GetAllAsync(Func<TodoItem, bool> predicate);
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<bool> UpdateAsync(Guid id, TodoItem item);
        Task<bool> UpdateBatchAsync(IEnumerable<TodoItem> items);
    }
}
