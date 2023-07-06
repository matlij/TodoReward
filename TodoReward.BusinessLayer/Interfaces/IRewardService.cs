using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Interfaces
{
    public interface IRewardService
    {
        Task<Reward> GenerateRandomAsync();
    }
}
