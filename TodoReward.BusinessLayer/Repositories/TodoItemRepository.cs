using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Repositories
{

    public class TodoItemRepository

        : ITodoItemRepository
    {
        private readonly List<TodoItem> _items;

        public TodoItemRepository()
        {
            _items = new List<TodoItem>()
            {
                new TodoItem { Title = "Foo", Points = 3 },
                new TodoItem { Title = "Bar", Points = 2 },
                new TodoItem { Title = "FooBar", Points = 1 },
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

            return Task.FromResult(items);
        }

        public async Task<bool> UpdateBatchAsync(IEnumerable<TodoItem> items)
        {
            foreach (var item in items)
            {
                await UpdateAsync(item.Id, item);
            }

            return true;
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
