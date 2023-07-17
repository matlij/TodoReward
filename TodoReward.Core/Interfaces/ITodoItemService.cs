using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface ITodoItemService
    {
        Task<(bool result, Reward? reward)> CompleteItemAsync(TodoItem item);
    }
}
