using System.Text.Json.Serialization;

namespace MSGraphWebhookListeneer.Models
{
    public class GraphNotification
    {
        [JsonPropertyName("subscriptionId")]
        public string? SubscriptionId { get; set; }

        [JsonPropertyName("subscriptionExpirationDateTime")]
        public DateTime? SubscriptionExpirationDateTime { get; set; }

        [JsonPropertyName("changeType")]
        public string? ChangeType { get; set; }

        [JsonPropertyName("resource")]
        public string? Resource { get; set; }

        [JsonPropertyName("clientState")]
        public string? ClientState { get; set; }

        [JsonPropertyName("tenantId")]
        public string? TenantId { get; set; }

        [JsonPropertyName("resourceData")]
        public ResourceData? ResourceData { get; set; }
    }
}
