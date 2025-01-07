using System.Text.Json.Serialization;

namespace HubSpotIntegrate.DTO
{
    /// <summary>
    /// Represents the payload for a successful Create operation in the Hubspot integration.
    /// </summary>
    public class SuccessPayloadDTO
    {

        /// <summary>
        /// Gets or sets the identifier of a Created object tha comes in response.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Seter of Id in case of vid exists.
        /// </summary>
        [JsonPropertyName("vid")]
        public long Vid { set => Id = value.ToString();}
    }
}
