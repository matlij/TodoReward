using TodoReward.Core.Extensions;

namespace TodoReward.Core.Models
{
    public class User : BaseEntity
    {
        private const int RewardLimit = 2;

        public IList<UserReward> Rewards { get; } = new List<UserReward>();
        public void AddRewards(TodoItemCompleteResult result)
        {
            foreach (var reward in result.GetAllRewards())
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

        public int MilstonesReached { get; set; }
        public int NoOfRewardsInCurrentMilstone
        {
            get
            {
                return (MilstonesReached * 2) + 2;
            }
        }
        public int NextMileStone
        {
            get
            {
                return PointsToNextMilestone(MilstonesReached);
            }
        }
        public double PercentageCompletedOfNextMilestone
        {
            get
            {
                var pointsToPrevoiusMilestone = PointsToNextMilestone(MilstonesReached - 1);
                var totaltPointsToReachNextMilestone = NextMileStone - pointsToPrevoiusMilestone;
                var pointsEarnedInThisMilestone = TotalPoints - pointsToPrevoiusMilestone;

                var percentage = (double)pointsEarnedInThisMilestone / totaltPointsToReachNextMilestone;
                return percentage;
            }
        }
        public bool HasReachedMilestone
        {
            get
            {
                return TotalPoints >= NextMileStone;
            }
        }

        private bool ShoudlGetReward
        {
            get
            {
                return PointsToNextReward <= 0;
            }
        }

        private static int PointsToNextMilestone(int milestone) => (milestone * milestone * 5) + 5;

        public Reward? RegisterCompletedTodo(TodoItem todoItem, IEnumerable<Reward> rewards)
        {
            TotalPoints += todoItem.Points;

            var reward = GetReward(todoItem, rewards);

            return reward;
        }

        private Reward? GetReward(TodoItem todoItem, IEnumerable<Reward> rewards)
        {
            if (!ShoudlGetReward)
            {
                return null;
            }

            TotalPointsRewarded += RewardLimit;
            return GenerateRandomReward(rewards);
        }

        public IEnumerable<Reward>? GetRewardsForMilestone(IEnumerable<Reward> rewards)
        {
            if (!HasReachedMilestone)
            {
                return null;
            }

            MilstonesReached++;

            var rewardsInMileStone = new List<Reward>();
            for (int i = 0; i < NoOfRewardsInCurrentMilstone; i++)
            {
                var randomReward = GenerateRandomReward(rewards);
                rewardsInMileStone.Add(randomReward);
            }

            return rewardsInMileStone;
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
