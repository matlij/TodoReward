namespace TodoReward.Core.Models
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

        public IEnumerable<Reward> GetAllRewards()
        {
            var rewardsToAdd = new List<Reward>();
            if (RewardsFromCompletedMilestone != null)
            {
                rewardsToAdd.AddRange(RewardsFromCompletedMilestone);
            }
            if (Reward != null)
            {
                rewardsToAdd.Add(Reward);
            }

            return rewardsToAdd;
        }
    }
}
