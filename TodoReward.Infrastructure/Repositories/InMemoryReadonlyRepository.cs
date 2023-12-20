using AutoBogus;
using Bogus;
using System.Collections.Frozen;
using System.Linq.Expressions;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Infrastructure.Repositories
{
    public class InMemoryReadonlyRepository<T> : IGenericReadonlyRepository<T> where T : BaseEntity
    {
        private readonly FrozenSet<T> _items;

        public InMemoryReadonlyRepository(FrozenSet<T> items)
        {
            _items = items;
        }

        public InMemoryReadonlyRepository()
        {
            var faker = new MyDefaultFaker();
            _items = faker.GenerateBetween(19, 20).ToFrozenSet();
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
