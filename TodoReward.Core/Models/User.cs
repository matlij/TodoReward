using TodoReward.Core.Extensions;

namespace TodoReward.Core.Models
{
    public class User : BaseEntity
    {
        private const int RewardLimit = 4;

        public IList<UserReward> Rewards { get; } = new List<UserReward>();
        public void AddRewards(IEnumerable<Reward> rewards)
        {
            foreach (var reward in rewards)
            {
                var userReward = new UserReward
                {
                    RewardId = reward.Id,
                    UserId = Id
                };

                Rewards.Add(userReward);
            }
        }

        public int TotalPoints { get; private set; }
        public int TotalPointsRewarded { get; private set; }
        public int PointsToNextReward
        {
            get
            {
                var unrewardedPoints = TotalPoints - TotalPointsRewarded;
                return RewardLimit - unrewardedPoints;
            }
        }

        public TodoItem? LastCompletedItem { get; set; }

        private bool ShoudlGetReward
        {
            get
            {
                return PointsToNextReward <= 0;
            }
        }

        public Reward? RegisterCompletedTodo(TodoItem todoItem, IEnumerable<Reward> rewards)
        {
            TotalPoints += GetPointsForCompletedTodo(todoItem);

            var reward = GetReward(rewards);

            return reward;
        }

        private static int GetPointsForCompletedTodo(TodoItem todoItem) => 
            !todoItem.DueDate.HasValue ||
            todoItem.DueDate.Value.Date.Day >= DateTime.UtcNow.Date.Day
                ? 2
                : 1;

        private Reward? GetReward(IEnumerable<Reward> rewards)
        {
            if (!ShoudlGetReward)
            {
                return null;
            }

            TotalPointsRewarded += RewardLimit;
            return GenerateRandomReward(rewards);
        }

        private static Reward GenerateRandomReward(IEnumerable<Reward> rewards)
        {
            if (rewards == null || !rewards.Any())
            {
                throw new ArgumentNullException(nameof(rewards));
            }

            var pot = GeneratePot(rewards);
            return rewards.GetRandomFromPot(pot);
        }

        private static IList<string> GeneratePot(IEnumerable<Reward> rewards)
        {
            return rewards
                .SelectMany(r => Enumerable.Repeat(r.Id, r.Propability))
                .ToList();
        }
    }
}
