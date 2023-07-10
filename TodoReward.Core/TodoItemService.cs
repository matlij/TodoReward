using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Core
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IRewardService _rewardService;
        private readonly IGenericRepository<TodoItem> _todoRepository;
        private readonly IGenericRepository<User> _userRepository;

        private const int RewardLimit = 4;

        public TodoItemService(IRewardService rewardService, IGenericRepository<TodoItem> todoRepository, IGenericRepository<User> userRepository)
        {
            _rewardService = rewardService;
            _todoRepository = todoRepository;
            _userRepository = userRepository;
        }

        public async Task<Reward?> CompleteItemAsync(TodoItem item)
        {
            await CompleteTodoItem(item);

            return await GetReward(item);
        }

        private async Task<Reward?> GetReward(TodoItem item)
        {
            var user = (await _userRepository.GetAllAsync()).First();

            user.TotalPoints += item.Points;
            if (user.TotalPointsNotRewarded < RewardLimit)
            {
                return null;
            }

            user.TotalPointsRewarded += RewardLimit;

            var reward = await _rewardService.GenerateRandomAsync();

            user.Rewards.Add(new UserReward { Reward = reward });

            return reward;
        }

        private async Task CompleteTodoItem(TodoItem item)
        {
            item.IsCompleted = true;
            await _todoRepository.UpdateAsync(item.Id, item);
        }
    }
}
