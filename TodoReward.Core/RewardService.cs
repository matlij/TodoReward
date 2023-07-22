using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Core
{
    public class RewardService : IRewardService
    {
        private readonly IGenericRepository<Reward> _repository;

        public RewardService(IGenericRepository<Reward> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returns a random reward based on the <see cref="Reward.Propability"/> property value
        /// </summary>
        /// <returns></returns>
        public async Task<Reward> GenerateRandomAsync()
        {
            var rewards = (await _repository.GetAllAsync()).ToArray();
            if (rewards == null || rewards.Length == 0)
            {
                return new Reward() { Title = "Unknown" };
            }

            var pot = GeneratePot(rewards);
            return GetRandomRewardFromPot(pot, rewards);
        }

        private static Reward GetRandomRewardFromPot(IList<Guid> pot, IEnumerable<Reward> rewards)
        {
            var rnd = new Random();

            var i = rnd.Next(pot.Count - 1);
            
            var rndRewardId = pot[i];

            return rewards.Single(r => r.Id == rndRewardId);
        }

        private static IList<Guid> GeneratePot(Reward[] rewards)
        {
            return rewards
                .SelectMany(r => Enumerable.Repeat(r.Id, r.Propability))
                .ToList();
        }
    }
}
