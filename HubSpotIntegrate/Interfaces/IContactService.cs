using HubSpotIntegrate.Dto;
namespace HubSpotIntegrate.Interfaces
{
    /// <summary>
    /// Interface for managing contacts in the Hubspot integration.
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <param name="contact">The contact dto for creation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateContact(ContactDTO contact);

        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <param name="contact">The contact dto for upsert.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpsertContact(ContactDTO contact);

        ///// <summary>
        ///// Retrieves a list of contacts.
        ///// </summary>
        ///// <returns>A task representing the asynchronous operation, containing a list of contact DTOs.</returns>
        Task<IList<ContactDTO>> GetContacts();
    }
}


