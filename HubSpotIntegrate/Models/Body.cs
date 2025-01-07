using System.Text.Json.Serialization;

namespace HubSpotIntegrate.Models
{
    /// <summary>
    /// Represents a generic body model for Post and Patch with a trace ID and properties.
    /// </summary>
    /// <typeparam name="T">The type of the properties.</typeparam>
    /// <param name="traceId">The trace ID associated with the post.</param>
    /// <param name="input">The properties of the post.</param>
    public class Body<T>(string traceId, T input)
    {

        /// <summary>
        /// Gets or sets the object trace ID for local control.
        /// </summary>
        [JsonPropertyName("objectWriteTraceId")]
        public string ObjectWriteTraceId { get; set; } = traceId;

        /// <summary>
        /// Gets or sets the object properties to Post or Patch.
        /// </summary>
        [JsonPropertyName("properties")]
        public T Properties { get; set; } = input;
    }

}
