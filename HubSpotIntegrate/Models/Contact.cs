using HubSpotIntegrate.Dto;
using System.Text.Json.Serialization;

namespace HubSpotIntegrate.Models
{
    /// <summary>
    /// Represents a contact with properties mapped from a ContactDTO object to serialize in right.
    /// </summary>
    /// <param name="input">The ContactDTO object containing the contact details.</param>
    public class Contact(ContactDTO input)
    {
        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; } = input.FirstName;

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        [JsonPropertyName("lastname")]
        public string LastName { get; set; } = input.LastName;

        /// <summary>
        /// Gets or sets the email address of the contact.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; } = input.Email;

        /// <summary>
        /// Gets or sets the gender of the contact.
        /// </summary>
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = input.Gender;

        /// <summary>
        /// Gets or sets the phone number of the contact.
        /// </summary>
        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; } = input.PhoneNumber;
    }
}
