using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer
{

    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoRepository;
        private readonly IRewardRepository _rewardRepository;
        private readonly IUserRepository _userRepository;

        private const int RewardLimit = 4;

        public TodoItemService(ITodoItemRepository repository, IRewardRepository rewardRepository, IUserRepository userRepository)
        {
            _todoRepository = repository;
            _rewardRepository = rewardRepository;
            _userRepository = userRepository;
        }

        public async Task<Reward> CompleteItemAsync(TodoItem item)
        {
            await CompleteTodoItem(item);

            return await GetReward(item);
        }

        private async Task<Reward> GetReward(TodoItem item)
        {
            var user = await _userRepository.GetAsync();

            user.TotalPoints += item.Points;
            if (user.TotalPointsNotRewarded < RewardLimit)
            {
                return null;
            }

            user.TotalPointsRewarded += RewardLimit;

            return await _rewardRepository.GetRandomAsync();
        }

        private async Task CompleteTodoItem(TodoItem item)
        {
            item.IsCompleted = true;
            await _todoRepository.UpdateAsync(item.Id, item);
        }
    }
}
