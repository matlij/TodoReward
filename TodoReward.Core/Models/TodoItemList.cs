using TodoReward.Core.Models;

namespace TodoReward.Infrastructure.Models.ExternalModels
{
    public class TodoItemList : BaseEntity
    {
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}
