using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using HubSpotIntegrate.DTO;

namespace HubSpotIntegrate.Gateways
{
    /// <summary>
    /// BaseGateway class provides methods to perform HTTP operations such as GET, POST, and PATCH for child Gateways.
    /// </summary>
    /// <typeparam name="T">The type of the payload for the POST and PATCH method.</typeparam>
    public abstract class BaseGateway<T>
    {
        /// <summary>
        /// The HttpClient instance used to perform HTTP operations.
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGateway{T}"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL for the HTTP client.</param>
        /// <param name="token">The authorization token for the HTTP client.</param>
        /// <exception cref="Exception">Thrown when baseUrl or token is null.</exception>
        protected BaseGateway(string baseUrl, string token)
        {
            if (baseUrl == null || token == null)
            {
                throw new Exception("Need to add env");
            }
            httpClient = new()
            {
                BaseAddress = new Uri(baseUrl),
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", token)
                }
            };
        }

        /// <summary>
        /// Performs a GET request to the specified URL.
        /// </summary>
        /// <param name="url">The URL to send the GET request to.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the HTTP response.</returns>
        protected async Task<HTTPResponseDTO> Get(string url = "")
        {
            using var response = await httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            return new HTTPResponseDTO(response.StatusCode, json);
        }

        /// <summary>
        /// Performs a POST request with the specified payload to the specified URL.
        /// </summary>
        /// <param name="payload">The payload to send in the POST request.</param>
        /// <param name="url">The URL to send the POST request to.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the HTTP response.</returns>
        protected async Task<HTTPResponseDTO> Post(T payload, string url = "")
        {
            var realUrl = httpClient.BaseAddress + url;
            var stringPayload = JsonSerializer.Serialize(payload);
            var requestContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(realUrl, requestContent);
            var json = await response.Content.ReadAsStringAsync();
            return new HTTPResponseDTO(response.StatusCode, json);
        }

        /// <summary>
        /// Performs a PATCH request with the specified payload to the specified URL.
        /// </summary>
        /// <param name="id">The identifier to append to the URL.</param>
        /// <param name="payload">The payload to send in the PATCH request.</param>
        /// <param name="url">The URL to send the PATCH request to.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the HTTP response.</returns>
        protected async Task<HTTPResponseDTO> Patch(string id, T payload, string url = "")
        {
            var realUrl = httpClient.BaseAddress + url + "/" + id;
            var response = await httpClient.PatchAsync(realUrl, JsonContent.Create(payload));
            var json = await response.Content.ReadAsStringAsync();
            return new HTTPResponseDTO(response.StatusCode, json);
        }
    }
}