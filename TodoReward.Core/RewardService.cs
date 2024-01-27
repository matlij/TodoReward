using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Core
{
    public class RewardService : IRewardService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserReward> _userRewardRepository;
        private readonly IGenericReadonlyRepository<Reward> _rewardRepository;

        public RewardService(
            IGenericRepository<User> userRepository,
            IGenericRepository<UserReward> userRewardRepository,
            IGenericReadonlyRepository<Reward> rewardRepository)
        {
            _userRepository = userRepository;
            _userRewardRepository = userRewardRepository;
            _rewardRepository = rewardRepository;
        }

        public async Task<IEnumerable<Reward>?> RegisterRewardsOnUserAsync(IEnumerable<TodoItem> items, string userId)
        {
            var user = await GetUserByIdAsync(userId);
            var rewards = await _rewardRepository.GetAllAsync();

            var receivedRewards = new List<Reward>();
            foreach (var item in items)
            {
                var reward = user.RegisterCompletedTodo(item, rewards);
                if (reward != null)
                {
                    receivedRewards.Add(reward);
                }
            }

            await UpdateUserRewardsAsync(user, rewards);
            await _userRepository.UpdateAsync(user.Id, user);

            return rewards;
        }

        public async Task<Reward?> RegisterRewardOnUserAsync(TodoItem item, string userId)
        {
            var user = await GetUserByIdAsync(userId);
            var rewards = await _rewardRepository.GetAllAsync();

            var reward = user.RegisterCompletedTodo(item, rewards);

            if (reward != null)
            {
                await UpdateUserRewardsAsync(user, new List<Reward> { reward });
                await _userRepository.UpdateAsync(user.Id, user);
            }

            return reward;
        }

        private async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userRepository.GetByIdAsync(userId)
                   ?? throw new InvalidOperationException("Cannot find user with ID: " + userId);
        }

        private Task<bool> UpdateUserRewardsAsync(User user, IEnumerable<Reward> rewards)
        {
            user.AddRewards(rewards);
            return _userRewardRepository.UpdateRangeAsync(user.Rewards);
        }
    }
}
