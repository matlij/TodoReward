using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TodoReward.Infrastructure.Models.ExternalModels
{
    public class TodoistEventData
    {
        [JsonPropertyName("added_at")]
        public string AddedAt { get; set; }

        [JsonPropertyName("added_by_uid")]
        public string AddedByUid { get; set; }

        [JsonPropertyName("assigned_by_uid")]
        public object AssignedByUid { get; set; }

        [JsonPropertyName("checked")]
        public bool Checked { get; set; }

        [JsonPropertyName("child_order")]
        public int ChildOrder { get; set; }

        [JsonPropertyName("collapsed")]
        public bool Collapsed { get; set; }

        [JsonPropertyName("completed_at")]
        public string CompletedAt { get; set; }

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

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("labels")]
        public List<object> Labels { get; set; }

        [JsonPropertyName("parent_id")]
        public object ParentId { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("responsible_uid")]
        public object ResponsibleUid { get; set; }

        [JsonPropertyName("section_id")]
        public object SectionId { get; set; }

        [JsonPropertyName("sync_id")]
        public object SyncId { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
