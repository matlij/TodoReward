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

        public async Task<IEnumerable<TodoItemCompleteResult>?> RegisterRewardsOnUserAsync(IEnumerable<TodoItem> items, string userId)
        {
            var user = await GetUserByIdAsync(userId);
            var rewards = await _rewardRepository.GetAllAsync();

            var rewardResults = new List<TodoItemCompleteResult>();
            foreach (var item in items)
            {
                var result = RegisterCompletedTodo(user, item, rewards);
                rewardResults.Add(result);
            }

            await UpdateUserRewardsAsync(user, rewardResults);
            await _userRepository.UpdateAsync(user.Id, user);

            return rewardResults;
        }

        public async Task<TodoItemCompleteResult?> RegisterRewardOnUserAsync(TodoItem item, string userId)
        {
            var user = await GetUserByIdAsync(userId);
            var rewards = await _rewardRepository.GetAllAsync();

            var result = RegisterCompletedTodo(user, item, rewards);

            await UpdateUserRewardsAsync(user, new List<TodoItemCompleteResult> { result });
            await _userRepository.UpdateAsync(user.Id, user);

            return result;
        }

        private async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userRepository.GetByIdAsync(userId)
                   ?? throw new InvalidOperationException("Cannot find user with ID: " + userId);
        }

        private TodoItemCompleteResult RegisterCompletedTodo(User user, TodoItem item, IEnumerable<Reward> rewards)
        {
            return new TodoItemCompleteResult
            {
                Reward = user.RegisterCompletedTodo(item, rewards),
                RewardsFromCompletedMilestone = user.GetRewardsForMilestone(rewards)
            };
        }

        private async Task<IEnumerable<TodoItemCompleteResult>?> UpdateUserRewardsAsync(User user, IEnumerable<TodoItemCompleteResult> userRewards)
        {
            foreach (var reward in userRewards)
            {
                user.AddRewards(reward);
            }
            var updateSucceeded = await _userRewardRepository.UpdateRangeAsync(user.Rewards);
            return updateSucceeded ? userRewards : null;
        }
    }
}
