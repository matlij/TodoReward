using Azure.Data.Tables;
using AutoMapper;
using System.Linq.Expressions;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using Azure;
using Microsoft.Extensions.Options;
using TodoReward.Infrastructure.Options;
using TodoReward.Infrastructure.Models.StorageTable;

namespace TodoReward.Infrastructure.Repositories;

public class TableStorageRepository<T, TEntity> : IGenericRepository<T>
    where T : BaseEntity
    where TEntity : class, ITableEntity
{
    private readonly TableServiceClient _tableServiceClient;
    private readonly TableClient _tableClient;
    private readonly IMapper _mapper;

    public TableStorageRepository(IOptions<StorageTableOptions> options, IMapper mapper)
    {
        _tableServiceClient = new TableServiceClient(options.Value.ConnectionString);
        _tableClient = _tableServiceClient.GetTableClient(options.Value.TableName);
        _mapper = mapper;
    }

    public async Task<bool> AddAsync(T user)
    {
        try
        {
            var entity = _mapper.Map<TEntity>(user);
            await _tableClient.AddEntityAsync(entity);
            return true;
        }
        catch (RequestFailedException ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error adding entity: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            await _tableClient.DeleteEntityAsync(StorageTableConstants.StorageTablePartitionKey, id.ToString());
            return true;
        }
        catch (RequestFailedException ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error deleting entity: {ex.Message}");
            return false;
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            var query = _tableClient.QueryAsync<TEntity>();
            var users = new List<T>();

            await foreach (var entity in query)
            {
                users.Add(_mapper.Map<T>(entity));
            }

            return users;
        }
        catch (RequestFailedException ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error getting all entities: {ex.Message}");
            return Enumerable.Empty<T>();
        }
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        try
        {
            var entity = await _tableClient.GetEntityAsync<TEntity>(StorageTableConstants.StorageTablePartitionKey, id.ToString());
            return _mapper.Map<T>(entity);
        }
        catch (RequestFailedException ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error getting entity by ID: {ex.Message}");
            return null;
        }
    }

    public Task<IEnumerable<T>> GetBySpecificationAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetBySpecificationAsync(string filter)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(string id, T item)
    {
        try
        {
            var entity = _mapper.Map<TEntity>(item);
            await _tableClient.UpdateEntityAsync(entity, ETag.All);
            return true;
        }
        catch (RequestFailedException ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error updating entity: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> UpdateRangeAsync(IEnumerable<T> items)
    {
        try
        {
            var transactions = items.Select(
                i => new TableTransactionAction(TableTransactionActionType.UpsertMerge, _mapper.Map<TEntity>(i)));

            var response = await _tableClient.SubmitTransactionAsync(transactions);
            return response.Value.Any(r => r.IsError)
                ? false
                : true;
        }
        catch (RequestFailedException ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error updating entity: {ex.Message}");
            return false;
        }
    }
}

