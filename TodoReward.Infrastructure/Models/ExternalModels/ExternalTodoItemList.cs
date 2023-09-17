using TodoReward.Core.Models;

namespace TodoReward.Infrastructure.Models.ExternalModels
{
    public class ExternalTodoItemList
    {
        public IEnumerable<ExternalTodoItem> Items { get; set; } = new List<ExternalTodoItem>();
        public Dictionary<string, ExternalProject> Projects { get; set; } = new Dictionary<string, ExternalProject>();
        public Dictionary<string, ExternalSectionDto> Sections { get; set; } = new Dictionary<string, ExternalSectionDto>();
    }

    public class TodoItemList : BaseEntity
    {
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}
