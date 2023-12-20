using System.Text.Json.Serialization;

namespace TodoReward.Infrastructure.Models.ExternalModels;

public class TodoistCreateTask
{
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    [JsonPropertyName("project_id")]
    public string ProjectId { get; set; } = string.Empty;

    [JsonPropertyName("due_date")]
    public string? DueDate { get; set; }

    [JsonPropertyName("due_string")]
    public string? DueString { get; set; }

    [JsonPropertyName("due_lang")]
    public string? DueLanguage
    {
        get
        {
            return "sv";
        }
    }

    [JsonPropertyName("parent_id")]
    public string? ParentId { get; set; }
}
