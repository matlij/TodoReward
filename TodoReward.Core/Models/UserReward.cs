namespace TodoReward.Core.Models
{
    public class UserReward : BaseEntity
    {
        public Reward Reward { get; set; } = null;
        public Guid RewardId { get; set; }
        public User User { get; set; } = null;
        public Guid UserId { get; set; }

        public bool IsDone { get; set; }
    }
}
