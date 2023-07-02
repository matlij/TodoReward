using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Interfaces
{
    public interface IRewardRepository
    {
        Task<Reward> GetRandomAsync();
    }
}
