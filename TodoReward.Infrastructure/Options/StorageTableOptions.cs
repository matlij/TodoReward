using Azure.Data.Tables;

namespace TodoReward.Infrastructure.Options;

public class StorageTableOptions<T> where T : ITableEntity
{
    public string ConnectionString { get; set; } = string.Empty;
    public string TableName { get; set; } = string.Empty;
}

