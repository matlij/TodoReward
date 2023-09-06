using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net.Http.Json;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Infrastructure.Repositories
{
    public class ExternalTodoRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly ILogger<ExternalTodoRepository<T>> _logger;

        public ExternalTodoRepository(IHttpClientFactory httpClientFactory, IMapper mapper, ILogger<ExternalTodoRepository<T>> logger)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<bool> AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                using HttpClient client = _httpClientFactory.CreateClient("Todoist");
                var result = await client.GetFromJsonAsync<ExternalTodoItemList>("completed/get_all");

                return result?.Items.Select(_mapper.Map<T>) ?? Enumerable.Empty<T>();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }

            return Array.Empty<T>();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetBySpecificationAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, T item)
        {
            throw new NotImplementedException();
        }
    }
}
