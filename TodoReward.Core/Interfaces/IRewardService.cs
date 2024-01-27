using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface IRewardService
    {
        Task<Reward?> RegisterRewardOnUserAsync(TodoItem item, string userId);
        Task<IEnumerable<Reward>?> RegisterRewardsOnUserAsync(IEnumerable<TodoItem> items, string userId);
    }
}
