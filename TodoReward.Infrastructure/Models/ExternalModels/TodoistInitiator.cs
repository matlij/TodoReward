using System.Text.Json.Serialization;

namespace TodoReward.Infrastructure.Models.ExternalModels
{
    public class TodoistInitiator
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("image_id")]
        public string ImageId { get; set; }

        [JsonPropertyName("is_premium")]
        public bool IsPremium { get; set; }
    }
}
