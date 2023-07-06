namespace TodoReward.BusinessLayer.Models
{
    public class User : BaseEntity
    {
        public IList<Reward> Rewards { get; set; } = new List<Reward>();
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
