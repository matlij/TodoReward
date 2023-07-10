namespace TodoReward.Core.Models
{
    public class User : BaseEntity
    {
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
    }
}
