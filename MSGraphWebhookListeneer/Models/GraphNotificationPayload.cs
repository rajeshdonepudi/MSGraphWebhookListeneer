using System.Text.Json.Serialization;

namespace MSGraphWebhookListeneer.Models
{
    public class GraphNotificationPayload
    {
        [JsonPropertyName("value")]
        public List<GraphNotification>? Value { get; set; }
    }
}
