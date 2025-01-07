using HubSpotIntegrate.Dto;
using HubSpotIntegrate.Interfaces;
using Serilog;

namespace HubSpotIntegrate.Services
{
    /// <summary>
    /// Service class for managing contacts with AWS and HubSpot integrations.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ContactService"/> class.
    /// </remarks>
    /// <param name="awsClient">The AWS client for handling contact operations.</param>
    /// <param name="hubspotClient">The HubSpot client for handling contact operations.</param>
    /// <param name="legacyHubspotClient">The legacy HubSpot client for handling contact operations.</param>
    public class ContactService(IAwsGateway awsClient, IHubspotGateway hubspotClient, ILegacyHubspotGateway legacyHubspotClient) : IContactService
    {
        /// <summary>
        /// The AWS client for handling contact operations.
        /// </summary>
        /// 
        private readonly IAwsGateway _awsClient = awsClient;
        /// <summary>
        /// The HubSpot client for handling contact operations.
        /// </summary>
        private readonly IHubspotGateway _hubspotClient = hubspotClient;

        /// <summary>
        /// The legacy HubSpot client for handling contact operations.
        /// </summary>
        private readonly ILegacyHubspotGateway _legacyHubspotClient = legacyHubspotClient;

        /// <summary>
        /// Creates a new contact using HubSpot api.
        /// </summary>
        /// <param name="input">The contact dto for upsert.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateContact(ContactDTO input)
        {
            var response = await _hubspotClient.CreateContact(input);
            Log.Debug("Contact with ID: {P1} was *CREATED*", response);
        }


        /// <summary>
        /// Upsert a contact using Legacy HubSpot api.
        /// </summary>
        /// <param name="input">The contact dto for upsert.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpsertContact(ContactDTO input)
        {
            var response = await _legacyHubspotClient.UpsertContact(input);
            Log.Debug("Contact with ID: {P1} was *UPSERTED*", response);
        }

        /// <summary>
        /// Retrieves a list of contacts from AWS.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of contacts.</returns>
        public async Task<IList<ContactDTO>> GetContacts()
        {
            return await _awsClient.GetContacts();
        }
    }
}
