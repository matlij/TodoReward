using System.ComponentModel.DataAnnotations.Schema;

namespace TodoReward.Core.Models
{
    public class Reward : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class UserReward : BaseEntity
    {
        public Reward Reward { get; set; } = new();
        public bool IsDone { get; set; }
    }
}
