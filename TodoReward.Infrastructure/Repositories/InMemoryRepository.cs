using AutoBogus;
using AutoMapper;
using Bogus;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Infrastructure.Repositories
{
    public class InMemoryRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IList<T> _items;

        public InMemoryRepository()
        {
            var faker = new MyDefaultFaker();
            _items = faker.GenerateBetween(19, 20);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_items.AsEnumerable());
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_items.SingleOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<T>> GetBySpecificationAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(_items.Where(predicate.Compile()));
        }

        public Task<bool> AddAsync(T item)
        {
            _items.Add(item);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateAsync(Guid id, T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var existing = _items.SingleOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return Task.FromResult(false);
            }

            existing = item;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        private class MyDefaultFaker : AutoFaker<T>
        {
            public MyDefaultFaker()
            {
                var rnd = new Random();
                RuleForType(typeof(int), f => rnd.Next(1, 4));
            }
        }
    }

    public class ExternalTodoItemList
    {
        public List<ExternalTodoItem> Items { get; set; }
        public Dictionary<string, ExternalProject> Projects { get; set; }
        public Dictionary<string, SectionDto> Sections { get; set; }
    }

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

    public class ExternalProject
    {
        public int ChildOrder { get; set; }
        public bool Collapsed { get; set; }
        public string Color { get; set; }
        public string Id { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFavorite { get; set; }
        public string Name { get; set; }
        public object ParentId { get; set; }
        public bool Shared { get; set; }
        public object SyncId { get; set; }
        public string ViewStyle { get; set; }
    }

    public class SectionDto
    {
        // Define properties for the 'Section' class here, if needed.
    }
}
