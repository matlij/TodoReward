using System.Text.Json.Serialization;

namespace TodoReward.Infrastructure.Models.ExternalModels
{
    public class ExternalTodoItem
    {
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; } = string.Empty;

        public DateTime CompletedAt { get; set; }
        public object MetaData { get; set; } = string.Empty;
        public int NoteCount { get; set; }
        public List<object> Notes { get; set; } = new List<object>();
        public string SectionId { get; set; } = string.Empty;
        public string TaskId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
