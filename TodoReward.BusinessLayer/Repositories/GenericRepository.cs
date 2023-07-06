using AutoBogus;
using Bogus;
using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Repositories
{
    public class MyDefaultFaker<T> : AutoFaker<T> where T : class
    {
        public MyDefaultFaker()
        {
            var rnd = new Random();
            RuleForType(typeof(int), f => rnd.Next(1, 4));
        }
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IList<T> _items;

        public GenericRepository()
        {
            var faker = new MyDefaultFaker<T>();
            _items = faker.GenerateBetween(3, 5);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_items.AsEnumerable());
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_items.SingleOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<T>> GetBySpecificationAsync(Func<T, bool> predicate)
        {
            return Task.FromResult(_items.Where(predicate));
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
    }
}
