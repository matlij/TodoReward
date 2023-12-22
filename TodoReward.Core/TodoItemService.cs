using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Core
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IGenericRepository<TodoItem> _todoRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserReward> _userRewardRepository;
        private readonly IGenericReadonlyRepository<Reward> _rewardRepository;

        public TodoItemService(
            IGenericRepository<TodoItem> todoRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<UserReward> userRewardRepository,
            IGenericReadonlyRepository<Reward> rewardRepository)
        {
            _todoRepository = todoRepository;
            _userRepository = userRepository;
            _userRewardRepository = userRewardRepository;
            _rewardRepository = rewardRepository;
        }

        public async Task<bool> CompleteItemAsync(TodoItem item)
        {
            if (item.CompletedDate == default)
            {
                item.CompletedDate = DateTime.UtcNow;
            }
            return await _todoRepository.UpdateAsync(item.Id, item);
        }
    }
}
