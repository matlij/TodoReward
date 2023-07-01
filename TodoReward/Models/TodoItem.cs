namespace TodoReward.Models
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
        public string Title { get; set; }
        public int Score { get; set; }
        public bool IsDone { get; set; }
    }
}
