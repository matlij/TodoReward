using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer
{
    public class RewardService : IRewardService
    {
        private readonly IGenericRepository<Reward> _repository;

        public RewardService(IGenericRepository<Reward> repository)
        {
            _repository = repository;
        }

        public async Task<Reward> GenerateRandomAsync()
        {
            var rewards = (await _repository.GetAllAsync()).ToArray();
            if (rewards == null || rewards.Length == 0)
            {
                return new Reward() { Title = "Unknown" };
            }

            var rnd = new Random();
            var i = rnd.Next(rewards.Length - 1);
            var rndReward = rewards[i];

            return rndReward;
        }
    }
}
