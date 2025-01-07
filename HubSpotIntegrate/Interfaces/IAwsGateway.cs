using HubSpotIntegrate.Dto;

namespace HubSpotIntegrate.Interfaces
{
    /// <summary>
    /// IAwsGateway interface to deal with http operations for Aws.
    /// </summary>
    public interface IAwsGateway
    {
        /// <summary>
        /// Make the requst in Aws for contacts and parse then for the service.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of contacts.</returns>
        Task<IList<ContactDTO>> GetContacts();
    }
}
