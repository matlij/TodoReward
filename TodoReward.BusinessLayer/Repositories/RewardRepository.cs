using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Repositories
{
    public class RewardRepository : IRewardRepository
    {
        private readonly Reward[] _rewards;

        public RewardRepository()
        {
            _rewards = new Reward[]
            {
                new Reward() { Title = "Beer" },
                new Reward() { Title = "Coffea" },
                new Reward() { Title = "Candy" },
                new Reward() { Title = "Lunch out" },
                new Reward() { Title = "Episode of a series" },
            };
        }

        public Task<Reward> GetRandomAsync()
        {
            var rnd = new Random();
            var i = rnd.Next(_rewards.Length - 1);
            return Task.FromResult(_rewards[i]);
        }
    }
}
