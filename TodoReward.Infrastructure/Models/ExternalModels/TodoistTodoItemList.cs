namespace TodoReward.Infrastructure.Models.ExternalModels
{

    public class TodoistTodoItemList
    {
        public IEnumerable<TodoistCreateTask> Items { get; set; } = new List<TodoistCreateTask>();
        public Dictionary<string, TodoistProject> Projects { get; set; } = new Dictionary<string, TodoistProject>();
        public Dictionary<string, TodoistSectionDto> Sections { get; set; } = new Dictionary<string, TodoistSectionDto>();
    }
}
