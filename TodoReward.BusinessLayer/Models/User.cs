namespace TodoReward.BusinessLayer.Models
{
    public class User
    {
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
