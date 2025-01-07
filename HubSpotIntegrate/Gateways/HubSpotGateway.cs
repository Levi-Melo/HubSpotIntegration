using HubSpotIntegrate.Dto;
using HubSpotIntegrate.DTO;
using HubSpotIntegrate.DTO.Enums;
using HubSpotIntegrate.Interfaces;
using HubSpotIntegrate.Models;
using System.Text.Json;

namespace HubSpotIntegrate.Gateways
{
    /// <summary>
    /// HubspotGateway class to deal with http operations for Hubspot.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="HubspotGateway"/> class.
    /// </remarks>
    /// <param name="baseUrl">BaseURL for http operations.</param>
    /// <param name="token">Bearer token for http operations.</param>
    /// <exception cref="Exception">Thrown when baseUrl or token is null.</exception>
    public class HubspotGateway(string baseUrl, string token) : BaseGateway<Body<Contact>>(baseUrl, token), IHubspotGateway
    {
        /// <summary>
        /// Make the requst in Hubspot for create a contact.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <param name="contact">The contact dto for create.</param>
        public async Task<string> CreateContact(ContactDTO contact)
        {
            Body<Contact> payload = new(contact.Id.ToString(), new Contact(contact));
            var response = await Post(payload);
            response.IsValid(ValidationCases.Default);

            return JsonSerializer.Deserialize<SuccessPayloadDTO>(response.ResponseContent).Id;
        }
    }
}
