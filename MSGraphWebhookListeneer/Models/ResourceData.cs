using System.Text.Json.Serialization;

namespace MSGraphWebhookListeneer.Models
{
    public class ResourceData
    {
        [JsonPropertyName("@odata.type")]
        public string? OdataType { get; set; }

        [JsonPropertyName("@odata.id")]
        public string? OdataId { get; set; }

        [JsonPropertyName("@odata.etag")]
        public string? OdataEtag { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}
