using Azure;
using Azure.Data.Tables;

namespace TodoReward.Infrastructure.Models.StorageTable;

public class UserEntity : ITableEntity
{
    public int TotalPoints { get; set; }
    public int TotalPointsRewarded { get; set; }
    public int MilstonesReached { get; set; }
    public string PartitionKey { get; set; } = StorageTableConstants.StorageTablePartitionKey;
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}
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

