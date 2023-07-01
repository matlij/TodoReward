using TodoReward.Models;

namespace TodoReward.Services
{
    public interface ITodoItemService
    {
        Task<bool> AddAsync(TodoItem item);
        Task<IEnumerable<TodoItem>> GetAllAsync(Func<TodoItem, bool> predicate);
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<bool> UpdateAsync(Guid id, TodoItem item);
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

        public Task<IEnumerable<TodoItem>> GetAllAsync(Func<TodoItem, bool> predicate)
        {
            var items = _items.Where(predicate);

            return Task.FromResult(items as IEnumerable<TodoItem>);
        }

        public Task<bool> UpdateAsync(Guid id, TodoItem item)
        {
            var itemToUpdate = _items.SingleOrDefault(x => x.Id == id);
            if (itemToUpdate is null)
            {
                return Task.FromResult(false);
            }

            itemToUpdate = item;

            return Task.FromResult(true);
        }
    }
}
