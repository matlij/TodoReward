using System.Text.Json.Serialization;

namespace TodoReward.Infrastructure.Models.ExternalModels;

public class TodoistTask
{
    [JsonPropertyName("creator_id")]
    public string CreatorId { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("assignee_id")]
    public string AssigneeId { get; set; }

    [JsonPropertyName("assigner_id")]
    public string AssignerId { get; set; }

    [JsonPropertyName("comment_count")]
    public int CommentCount { get; set; }

    [JsonPropertyName("is_completed")]
    public bool IsCompleted { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("due")]
    public TodoistDue Due { get; set; }

    [JsonPropertyName("duration")]
    public object Duration { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("labels")]
    public List<string> Labels { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("priority")]
    public int Priority { get; set; }

    [JsonPropertyName("project_id")]
    public string ProjectId { get; set; }

    [JsonPropertyName("section_id")]
    public string SectionId { get; set; }

    [JsonPropertyName("parent_id")]
    public string ParentId { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}