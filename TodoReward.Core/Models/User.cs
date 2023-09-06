namespace TodoReward.Core.Models
{
    public class User : BaseEntity
    {
        private const int RewardLimit = 2;

        public IList<UserReward> Rewards { get; set; } = new List<UserReward>();
        public int TotalPoints { get; set; }
        public int TotalPointsRewarded { get; set; }
        public int TotalPointsNotRewarded
        {
            get
            {
                return TotalPoints - TotalPointsRewarded;
            }
        }

        public int MilstonesReached { get; set; }
        public int NoOfRewardsInCurrentMilstone
        {
            get
            {
                return (MilstonesReached * 2) + 2;
            }
        }

        public int PointsToNextReward
        {
            get
            {
                return (TotalPoints - TotalPointsRewarded) - RewardLimit;
            }
        }

        public int NextMileStone
        {
            get
            {
                return PointsToMilestone(MilstonesReached);
            }
        }

        public double PercentageCompletedOfNextMilestone
        {
            get
            {
                var pointsToPrevoiusMilestone = PointsToMilestone(MilstonesReached - 1);
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

        private int PointsToMilestone(int milestone)
        {
            return (milestone * milestone * 5) + 5;
        }
    }
}
