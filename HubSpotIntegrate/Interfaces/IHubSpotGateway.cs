using HubSpotIntegrate.Dto;

namespace HubSpotIntegrate.Interfaces
{
    /// <summary>
    /// IHubspotGateway interface to deal with http operations for Hubspot.
    /// </summary>
    public interface IHubspotGateway
    {
        /// <summary>
        /// Make the requst in Hubspot for create a contact.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<string> CreateContact(ContactDTO a);
    }
}
