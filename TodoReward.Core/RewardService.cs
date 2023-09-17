using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Core.Models.Constants;

namespace TodoReward.Core
{
    public class RewardService : IRewardService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserReward> _userRewardRepository;
        private readonly IGenericRepository<Reward> _rewardRepository;

        public RewardService(
            IGenericRepository<User> userRepository,
            IGenericRepository<UserReward> userRewardRepository,
            IGenericRepository<Reward> rewardRepository)
        {
            _userRepository = userRepository;
            _userRewardRepository = userRewardRepository;
            _rewardRepository = rewardRepository;
        }

        public async Task<TodoItemCompleteResult?> GetRewardAsync(TodoItem item)
        {
            var user = await _userRepository.GetByIdAsync(ModelConstants.UserId) ?? throw new InvalidOperationException("Cannot find user with ID: " + ModelConstants.UserId);
            var rewards = await _rewardRepository.GetAllAsync();

            var result = new TodoItemCompleteResult
            {
                Reward = user.RegisterCompletedTodo(item, rewards),
                RewardsFromCompletedMilestone = user.GetRewardsForMilestone(rewards)
            };

            user.AddRewards(result);
            var updateSucceeded = await _userRewardRepository.UpdateRangeAsync(user.Rewards);
            return updateSucceeded
                ? result
                : null;
        }
    }
}
