using System.Text.Json;
using HubSpotIntegrate.Dto;
using HubSpotIntegrate.DTO.Enums;
using HubSpotIntegrate.Interfaces;

namespace HubSpotIntegrate.Gateways
{
    /// <summary>
    /// AwsGateway class to deal with http operations for Aws.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AwsGateway"/> class.
    /// </remarks>
    /// <param name="baseUrl">The base URL for the HTTP client.</param>
    /// <param name="token">The authorization token for the HTTP client.</param>
    /// <exception cref="Exception">Thrown when baseUrl or token is null.</exception>
    public class AwsGateway(string baseUrl, string token) : BaseGateway<ContactDTO>(baseUrl, token), IAwsGateway
    {
        /// <summary>
        /// Make the requst in Aws for contacts and parse then for the service.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of contacts.</returns>
        public async Task<IList<ContactDTO>> GetContacts()
        {
            var response = await Get("/prod/contacts");
            response.IsValid(ValidationCases.Default);
            return JsonSerializer.Deserialize<IList<ContactDTO>>(response.ResponseContent);
        }
    }
}
