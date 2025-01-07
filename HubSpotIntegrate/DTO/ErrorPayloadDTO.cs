using System.Text.Json.Serialization;

namespace HubSpotIntegrate.DTO
{
    /// <summary>
    /// Represents the payload for a error Create operation in the Hubspot integration.
    /// </summary>
    public class ErrorPayloadDTO
    {
        /// <summary>
        /// Gets or sets the message of a Error object tha comes in response.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
