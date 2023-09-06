using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface ITodoItemService
    {
        Task<TodoItemCompleteResult> CompleteItemAsync(TodoItem item);
    }
}
