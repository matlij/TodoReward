using Azure;
using Azure.Data.Tables;

namespace TodoReward.Infrastructure.Models.StorageTable;

public class TodoItemEntity : ITableEntity
{
    public string Title { get; set; } = string.Empty;
    public int Points { get; set; }
    public DateTime? CompletedDate { get; set; }
    public DateTime? DueDate { get; set; }
    public string ProjectId { get; set; } = string.Empty;
    public string PartitionKey { get; set; } = StorageTableConstants.StorageTablePartitionKey;
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}

