namespace TodoReward.Core.Models;

public class TodoItem : BaseEntity
{
    private string? _dueString;
    private DateTime? _dueDate;

    public string Content { get; set; } = string.Empty;
    public bool IsCompleted
    {
        get
        {
            return CompletedDate != DateTime.MinValue;
        }
    }
    public DateTime? CompletedDate { get; set; }
    public DateTime? DueDate
    {
        get => _dueDate;
        set
        {
            if (DueString != null)
            {
                throw new InvalidOperationException($"Not allowed to set {nameof(DueDate)} when {nameof(DueString)} has value");
            }

            _dueDate = value;
        }
    }
    public string? DueString
    {
        get => _dueString;
        set
        {
            if (DueDate.HasValue)
            {
                throw new InvalidOperationException($"Not allowed to set {nameof(DueString)} when {nameof(DueDate)} has value");
            }

            _dueString = value;
        }
    }
    public string? ProjectId { get; set; }
    public string? ParentId { get; set; }

}
