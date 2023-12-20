using System.Text.Json.Serialization;

namespace TodoReward.Infrastructure.Models.ExternalModels
{
    public class TodoistPushNotification
    {
        [JsonPropertyName("event_data")]
        public TodoistEventData EventData { get; set; }

        [JsonPropertyName("event_name")]
        public string EventName { get; set; }

        [JsonPropertyName("initiator")]
        public TodoistInitiator Initiator { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
