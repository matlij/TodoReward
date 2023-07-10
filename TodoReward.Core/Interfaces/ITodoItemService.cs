using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface ITodoItemService
    {
        Task<Reward?> CompleteItemAsync(TodoItem item);
    }
}
