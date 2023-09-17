namespace TodoReward.Core.Models
{
    public class UserReward : BaseEntity
    {
        public Reward Reward { get; set; } = null;
        public string RewardId { get; set; }
        public User User { get; set; } = null;
        public string UserId { get; set; }

        public bool IsDone { get; set; }
    }
}
