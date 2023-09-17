namespace TodoReward.Infrastructure.Models.ExternalModels
{
    public class ExternalTodoItem
    {
        public DateTime CompletedAt { get; set; }
        public string Content { get; set; }
        public string Id { get; set; }
        public object MetaData { get; set; }
        public int NoteCount { get; set; }
        public List<object> Notes { get; set; }
        public string ProjectId { get; set; }
        public string SectionId { get; set; }
        public string TaskId { get; set; }
        public string UserId { get; set; }
    }
}
