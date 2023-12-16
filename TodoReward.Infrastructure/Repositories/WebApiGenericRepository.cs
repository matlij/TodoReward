using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Infrastructure.Repositories;

public class WebApiGenericRepository<T, TExternal> : IGenericRepository<T> where T : BaseEntity
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly ILogger<WebApiGenericRepository<T,TExternal>> _logger;

    public WebApiGenericRepository(
        HttpClient httpClient,
        IMapper mapper, 
        ILogger<WebApiGenericRepository<T, TExternal>> logger)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> AddAsync(T item)
    {
        var requestBody = _mapper.Map<T, TExternal>(item);

        var response = await _httpClient.PostAsJsonAsync("tasks", requestBody);

        var result = response.IsSuccessStatusCode;
        if (!result)
        {
            _logger.LogWarning("Failed to create Todo item. Url: {url}. Body: {content}", _httpClient.BaseAddress, JsonSerializer.Serialize(requestBody));
        }

        return result;
    }

    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<IEnumerable<TExternal>>("");

        return result?.Select(r => _mapper.Map<T>(r)) ?? Enumerable.Empty<T>();
    }

    public Task<T?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetBySpecificationAsync(Expression<Func<TExternal, bool>> predicate)
    {
        var result = await _httpClient.GetFromJsonAsync<IEnumerable<TExternal>>("");

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

