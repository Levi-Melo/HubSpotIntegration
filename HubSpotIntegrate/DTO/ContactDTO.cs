using System.Text.Json.Serialization;

namespace HubSpotIntegrate.Dto
{
    /// <summary>
    /// Represents a contact data transfer object (DTO) for integration with HubSpot.
    /// </summary>
    /// 
    public class ContactDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the contact.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the contact.
        /// </summary>

        [JsonPropertyName("email")]
        public string Email { get; set; }


        /// <summary>
        /// Gets or sets the gender of the contact.
        /// </summary>
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the contact.
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
