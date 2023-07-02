namespace TodoReward.BusinessLayer.Models
{
    public class Reward
    {
        public Reward(Guid id)
        {
            Id = id;
        }
        public Reward()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
