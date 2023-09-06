using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Core
{
    public class TodoItemCompleteResult
    {
        public bool RewardReceived
        {
            get
            {
                return Reward != null;
            }
        }
        public Reward? Reward { get; set; }

        public bool MilestoneReached
        {
            get
            {
                return RewardsFromCompletedMilestone?.Any() ?? false;
            }
        }
        public IEnumerable<Reward>? RewardsFromCompletedMilestone { get; set; }
    }

    public class TodoItemService : ITodoItemService
    {
        private readonly IRewardService _rewardService;
        private readonly IGenericRepository<TodoItem> _todoRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserReward> _userRewardRepository;

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

        public async Task<TodoItemCompleteResult> CompleteItemAsync(TodoItem item)
        {
            var result = new TodoItemCompleteResult();

            item.IsCompleted = true;
            var updateTodoSucceeded = await _todoRepository.UpdateAsync(item.Id, item);
            if (updateTodoSucceeded == false)
            {
                return result;
            }

            var user = await _userRepository.GetByIdAsync(ModelConstants.UserId)
                ?? throw new InvalidOperationException("Cannot find user with ID: " + ModelConstants.UserId);
            user.TotalPoints += item.Points;

            var reward = await _rewardService.GetRewardAsync(user);
            result.Reward = reward;

            var rewards = await _rewardService.GetRewardsForMilestone(user);
            result.RewardsFromCompletedMilestone = rewards;

            var updateUserSucceeded = await UpdateUser(user, reward, result.Reward);
            if (updateUserSucceeded == false)
            {
                return result;
            }

            return result;
        }

        private async Task<bool> UpdateUser(User user, params Reward?[] rewards)
        {
            if (rewards is null)
            {
                return false;
            }

            foreach (var reward in rewards)
            {
                if (reward is null)
                {
                    continue;
                }

                var userReward = new UserReward
                {
                    RewardId = reward.Id,
                    UserId = user.Id
                };
                await _userRewardRepository.AddAsync(userReward);
            }

            return await _userRepository.UpdateAsync(user.Id, user);

        }
    }
}
