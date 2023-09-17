namespace TodoReward.Core.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity(Guid id)
        {
            Id = id.ToString();
        }
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
    }
}
