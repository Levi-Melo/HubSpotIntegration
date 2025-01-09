using System.Text.Json.Serialization;

namespace HubSpotIntegrate.Models
{
    public class Input
    {
        /// Gets or sets of property key name.

        [JsonPropertyName("property")]
        public string Property { get; set; }

        /// Gets or sets of property value.
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
