using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Core
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IRewardService _rewardService;
        private readonly IGenericRepository<TodoItem> _todoRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserReward> _userRewardRepository;

        private const int RewardLimit = 4;

        public TodoItemService(
            IRewardService rewardService,
            IGenericRepository<TodoItem> todoRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<UserReward> userRewardRepository)
        {
            _rewardService = rewardService;
            _todoRepository = todoRepository;
            _userRepository = userRepository;
            _userRewardRepository = userRewardRepository;
        }

        public async Task<(bool, Reward?)> CompleteItemAsync(TodoItem item)
        {
            item.IsCompleted = true;
            var updateTodoSucceeded = await _todoRepository.UpdateAsync(item.Id, item);
            if (updateTodoSucceeded == false)
            {
                return (false, null);
            }

            var user = await _userRepository.GetByIdAsync(ModelConstants.UserId) 
                ?? throw new InvalidOperationException("Cannot find user with ID: " + ModelConstants.UserId);
            user.TotalPoints += item.Points;

            var reward = await GetReward(user);
            var updateUserSucceeded = await UpdateUser(user, reward);

            return (updateUserSucceeded && updateTodoSucceeded, reward);
        }

        private async Task<bool> UpdateUser(User user, Reward? reward)
        {
            if (reward is not null)
            {
                var userReward = new UserReward 
                { 
                    RewardId = reward.Id, 
                    UserId = user.Id 
                };
                await _userRewardRepository.AddAsync(userReward);

                user.TotalPointsRewarded += RewardLimit;
            }

            return await _userRepository.UpdateAsync(user.Id, user);
        }

        private async Task<Reward?> GetReward(User user)
        {
            if (user.TotalPointsNotRewarded < RewardLimit)
            {
                return null;
            }

            return await _rewardService.GenerateRandomAsync();
        }
    }
}
