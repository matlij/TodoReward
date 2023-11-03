using AutoBogus;
using Bogus;
using System.Linq.Expressions;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Infrastructure.Repositories
{
    public class InMemoryRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IList<T> _items;

        public InMemoryRepository(IList<T> items)
        {
            _items = items;
        }

        public InMemoryRepository()
        {
            var faker = new MyDefaultFaker();
            _items = faker.GenerateBetween(19, 20);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_items.AsEnumerable());
        }

        public Task<T?> GetByIdAsync(string id)
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

        public Task<bool> UpdateAsync(string id, T item)
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

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetBySpecificationAsync(string filter)
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
}
