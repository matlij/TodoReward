using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface IRewardService
    {
        Task<TodoItemCompleteResult?> RegisterRewardOnUserAsync(TodoItem item, string userId);
        Task<IEnumerable<TodoItemCompleteResult>?> RegisterRewardsOnUserAsync(IEnumerable<TodoItem> items, string userId);
    }
}
