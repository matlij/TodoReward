namespace TodoReward.Core.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity(Guid id)
        {
            Id = id;
        }
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
