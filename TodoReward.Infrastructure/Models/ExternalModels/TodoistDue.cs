using System.Text.Json.Serialization;

namespace TodoReward.Infrastructure.Models.ExternalModels
{
    public class TodoistDue
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("is_recurring")]
        public bool IsRecurring { get; set; }

        [JsonPropertyName("datetime")]
        public DateTime Datetime { get; set; }

        [JsonPropertyName("string")]
        public string? StringRepresentation { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }
    }
}
