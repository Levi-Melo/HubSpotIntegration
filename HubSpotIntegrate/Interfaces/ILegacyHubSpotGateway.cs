using HubSpotIntegrate.Dto;
namespace HubSpotIntegrate.Interfaces
{
    /// <summary>
    /// ILegacyHubspotGateway interface to deal with http operations for Hubspot.
    /// </summary>
    public interface ILegacyHubspotGateway
    {
        /// <summary>
        /// Make the requst in Hubspot for upsert a contact.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<string> UpsertContact(ContactDTO input);
    }
}
