using System.ComponentModel.DataAnnotations.Schema;

namespace TodoReward.Core.Models
{
    public class Reward : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
