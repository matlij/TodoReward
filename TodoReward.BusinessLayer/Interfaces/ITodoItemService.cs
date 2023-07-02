using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Interfaces
{
    public interface ITodoItemService
    {
        Task<Reward> CompleteItemAsync(TodoItem item);
    }
}
