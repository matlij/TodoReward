namespace TodoReward.Core.Models
{

    public class TodoItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int Points { get; set; }
        public bool IsCompleted { get; set; }
        //public DateTime CompletedDate { get; set; }
    }
}
