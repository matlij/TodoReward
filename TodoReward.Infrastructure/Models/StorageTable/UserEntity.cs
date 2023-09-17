using Azure;
using Azure.Data.Tables;

namespace TodoReward.Infrastructure.Models.StorageTable;

public class UserEntity : ITableEntity
{
    public UserEntity(Guid id)
    {
        PartitionKey = "Users";
        RowKey = id.ToString();
    }

    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    public int TotalPoints { get; set; }
}

