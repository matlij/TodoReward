using Azure;
using Azure.Data.Tables;

namespace TodoReward.Infrastructure.Models.StorageTable;

public class UserRewardEntity : ITableEntity
{
    public string RewardId { get; set; }
    public string UserId { get; set; }
    public bool IsDone { get; set; }

    public string PartitionKey { get; set; } = StorageTableConstants.StorageTablePartitionKey;
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}

