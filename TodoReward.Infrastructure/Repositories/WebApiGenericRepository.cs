using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net.Http.Json;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Infrastructure.Models.ExternalModels;

namespace TodoReward.Infrastructure.Repositories;

public class WebApiGenericRepository<T, TExternal> : IGenericRepository<T> where T : BaseEntity
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly ILogger<WebApiGenericRepository<T,TExternal>> _logger;

    public WebApiGenericRepository(
        HttpClient httpClient,
        IMapper mapper, 
        ILogger<WebApiGenericRepository<T, TExternal>> logger)
    {
        //_httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task<bool> AddAsync(T item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using HttpClient client = _httpClientFactory.CreateClient();
        var result = await client.GetFromJsonAsync<IEnumerable<TExternal>>("");

        return result?.Select(r => _mapper.Map<T>(r)) ?? Enumerable.Empty<T>();
    }

    public Task<T?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetBySpecificationAsync(Expression<Func<TExternal, bool>> predicate)
    {
        using HttpClient client = _httpClientFactory.CreateClient();

        var result = await client.GetFromJsonAsync<IEnumerable<TExternal>>("");

        return result?
            .Where(predicate.Compile())
            .Select(r => _mapper.Map<T>(r)) ?? Enumerable.Empty<T>();

    }

    public async Task<IEnumerable<T>> GetBySpecificationAsync(string filter)
    {
        var result = await _httpClient.GetFromJsonAsync<TExternal>($"?{filter}");

        return _mapper.Map<IEnumerable<T>>(result);
    }

    public Task<IEnumerable<T>> GetBySpecificationAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(string id, T item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateRangeAsync(IEnumerable<T> items)
    {
        throw new NotImplementedException();
    }
}

