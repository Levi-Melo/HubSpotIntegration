using HubSpotIntegrate.DTO.Enums;
using System.Net;

namespace HubSpotIntegrate.DTO
{
    /// <summary>
    /// Represents an HTTP response with status code and content.
    /// </summary>
    public class HTTPResponseDTO
    {
        /// <summary>
        /// Gets the HTTP status code of the response.
        /// </summary>
        public readonly HttpStatusCode StatusCode;

        /// <summary>
        /// Gets the content of the HTTP response.
        /// </summary>
        public readonly string ResponseContent;

        /// <summary>
        /// Dictionary containing validation cases and their corresponding valid status codes.
        /// </summary>
        private readonly Dictionary<ValidationCases, IList<HttpStatusCode>> Validations;

        /// <summary>
        /// Initializes a new instance of the <see cref="HTTPResponseDTO"/> class.
        /// </summary>
        /// <param name="StatusCode">The HTTP status code of the response.</param>
        /// <param name="ResponseContent">The content of the HTTP response.</param>
        public HTTPResponseDTO(HttpStatusCode StatusCode, string ResponseContent)
        {
            this.StatusCode = StatusCode;
            this.ResponseContent = ResponseContent;
            this.Validations = new Dictionary<ValidationCases, IList<HttpStatusCode>>
            {
                { ValidationCases.Default, new List<HttpStatusCode> { HttpStatusCode.OK, HttpStatusCode.Created } }
            };
        }

        /// <summary>
        /// Validates the HTTP response based on the specified validation type.
        /// </summary>
        /// <param name="ValidationType">The type of validation to perform.</param>
        /// <exception cref="Exception">Thrown when the response status code is not valid for the specified validation type.</exception>
        public void IsValid(ValidationCases ValidationType)
        {
            if (!Validations[ValidationType].Contains(StatusCode))
            {
                throw new Exception($"Error: {StatusCode} - {ResponseContent}");
            }
        }
    }
}