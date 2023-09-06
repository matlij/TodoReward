using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Core
{
    public class RewardService : IRewardService
    {
        private readonly IGenericRepository<Reward> _rewardRepository;

        private const int RewardLimit = 2;

        public RewardService(IGenericRepository<Reward> repository)
        {
            _rewardRepository = repository;
        }

        public async Task<Reward?> GetRewardAsync(User user)
        {
            var receiveReward = user.TotalPointsNotRewarded >= RewardLimit;
            if (!receiveReward)
            {
                return null;
            }

            user.TotalPointsRewarded += RewardLimit;
            return await GenerateRandomRewardAsync();
        }

        public async Task<IEnumerable<Reward>?> GetRewardsForMilestone(User user)
        {
            if (!user.HasReachedMilestone)
            {
                return null;
            }
            user.MilstonesReached++;

            var rewards = await _rewardRepository.GetAllAsync();
            var rewardsInMileStone = new List<Reward>();
            for (int i = 0; i < user.NoOfRewardsInCurrentMilstone; i++)
            {
                var randomReward = GenerateRandomReward(rewards);
                rewardsInMileStone.Add(randomReward);
            }


            return rewardsInMileStone;
        }

        /// <summary>
        /// Returns a random reward based on the <see cref="Reward.Propability"/> property value
        /// </summary>
        /// <returns></returns>
        private async Task<Reward> GenerateRandomRewardAsync()
        {
            var rewards = await _rewardRepository.GetAllAsync();
            return GenerateRandomReward(rewards);
        }

        /// <summary>
        /// Returns a random reward based on the <see cref="Reward.Propability"/> property value
        /// </summary>
        /// <returns></returns>
        private static Reward GenerateRandomReward(IEnumerable<Reward>? rewards)
        {
            if (rewards == null || !rewards.Any())
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

        private static IList<Guid> GeneratePot(IEnumerable<Reward> rewards)
        {
            return rewards
                .SelectMany(r => Enumerable.Repeat(r.Id, r.Propability))
                .ToList();
        }
    }
}
