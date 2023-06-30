using System.Collections.ObjectModel;
using TodoReward.Models;

namespace TodoReward.Services
{
    public interface ITodoItemService
    {
        Task<bool> AddAsync(TodoItem item);
        Task<IEnumerable<TodoItem>> GetAllAsync();
    }

    public class TodoItemService : ITodoItemService
    {
        private readonly List<TodoItem> _items;

        public TodoItemService()
        {
            _items = new List<TodoItem>()
            {
                new TodoItem { Title = "Foo" },
                new TodoItem { Title = "Bar" },
            };

        }

        public Task<bool> AddAsync(TodoItem item)
        {
            _items.Add(item);

            return Task.FromResult(true);
        }

        public Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return Task.FromResult(_items as IEnumerable<TodoItem>);
        }
    }
}
