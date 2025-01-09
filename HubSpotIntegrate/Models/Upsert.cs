using System.Text.Json.Serialization;

namespace HubSpotIntegrate.Models
{
    public class Upsert
    {
        /// <summary>
        /// List of input properties.
        /// </summary>
        [JsonPropertyName("properties")]

        public IList<Input> Properties { get; set; }
    }
}
