using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface ITodoItemService
    {
        Task<bool> CompleteItemAsync(TodoItem item);
    }
}
