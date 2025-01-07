using HubSpotIntegrate.Dto;
using HubSpotIntegrate.DTO;
using HubSpotIntegrate.DTO.Enums;
using HubSpotIntegrate.Interfaces;
using HubSpotIntegrate.Models;
using System.Text.Json;

namespace HubSpotIntegrate.Gateways
{
    /// <summary>
    /// LegacyHubspotGateway class to deal with http operations for Hubspot.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="LegacyHubspotGateway"/> class.
    /// </remarks>
    /// <param name="baseUrl">BaseURL for http operations.</param>
    /// <param name="token">Bearer token for http operations.</param>
    /// <exception cref="Exception">Thrown when baseUrl or token is null.</exception>
    public class LegacyHubspotGateway(string baseUrl, string token) : BaseGateway<Upsert>(baseUrl, token), ILegacyHubspotGateway
    {
        /// <summary>
        /// Make the requst in Hubspot for upsert a contact.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <param name="input">The contact dto for upsert.</param>
        public async Task<string> UpsertContact(ContactDTO input)
        {
            var upsert = new Upsert
            {
                Properties =
                [
                    new() { Property = "firstname", Value = input.FirstName },
                    new() { Property = "lastname", Value = input.LastName },
                    new() { Property = "gender", Value = input.Gender },
                    new() { Property = "phone", Value = input.PhoneNumber }
                ]
            };

            var response = await Post(upsert, "/createOrUpdate/email/" + input.Email);

            response.IsValid(ValidationCases.Default);

            return JsonSerializer.Deserialize<SuccessPayloadDTO>(response.ResponseContent).Id;
        }
    }
}
