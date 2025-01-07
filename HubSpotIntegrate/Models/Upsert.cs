using System.Text.Json.Serialization;

namespace HubSpotIntegrate.Models
{
    public class Input
    {
        [JsonPropertyName("property")]
        public string Property { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
    public class Upsert
    {
        /// <summary>
        /// Gets or sets the Inputs.
        /// </summary>
        [JsonPropertyName("properties")]

        public IList<Input> Properties { get; set; }
    }

}
