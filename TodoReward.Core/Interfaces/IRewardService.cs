using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface IRewardService
    {
        Task<Reward?> GetRewardAsync(User user);
        Task<IEnumerable<Reward>?> GetRewardsForMilestone(User user);
    }
}
