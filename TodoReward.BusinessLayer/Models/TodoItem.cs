namespace TodoReward.BusinessLayer.Models
{
    public class TodoItem
    {
        public TodoItem(Guid id)
        {
            Id = id;
        }
        public TodoItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Title { get; set; } = string.Empty;
        public int Points { get; set; }
        public bool IsCompleted { get; set; }
        //public DateTime CompletedDate { get; set; }
    }
}
