using HubSpotIntegrate.Dto;
using HubSpotIntegrate.Interfaces;
using Serilog;

namespace HubSpotIntegrate.Facades
{
    /// <summary>
    /// Facade class responsible for integrating of contacts using ContactService.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="IntegrationFacade"/> class.
    /// </remarks>
    /// <param name="contactService">The contact service to be used for integration.</param>
    /// <param name="TaskCapacity">The task capacity using by msLimit.</param>
    /// <param name="msLimit">The ms limit to don't exced ratelimit of apis.</param>
    public class IntegrationFacade
    (IContactService contactService, int TaskCapacity, int msLimit) : IIntegrationFacade
    {
        private readonly IContactService _contactService = contactService;
        /// <summary>
        /// Processes contacts in parallel with a limit of TaskCapacity concurrent tasks per msLimit.
        /// </summary>
        /// <remarks>
        /// The contacts are divided by 2, repective with email and witout email, them processed on parallel while each thread process TaskCapacity simultaneously
        /// </remarks>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task MultiProcess()
        {
            Log.Information("Starting process");

            var contacts = await _contactService.GetContacts();

            List<Task> tasks = new(capacity: TaskCapacity);

            var contactsWithEmail = contacts.Where(p => p.Email != null).ToList();
            var contactsWithOutEmail = contacts.Where(p => p.Email == null).ToList();

            tasks.Add(ProcessContacts(contactsWithEmail, _contactService.UpsertContact));
            tasks.Add(ProcessContacts(contactsWithOutEmail, _contactService.CreateContact));

            await Task.WhenAll(tasks);

            Log.Information("All Process was finished");
            Log.Information("[{P1}] was created and [{P2}] was upserted", contactsWithOutEmail.Count, contactsWithEmail.Count);
        }

        /// <summary>
        /// Loop for process a list of contacts.
        /// </summary>
        /// <param name="contacts">list of contacts to be processed.</param>
        /// <param name="process">method to process a single contact.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>

        private async Task ProcessContacts(IList<ContactDTO> contacts, Func<ContactDTO, Task> process)
        {
            List<Task> tasks = new(capacity: TaskCapacity);
            foreach (var contact in contacts)
            {
                tasks.Add(process(contact));
                if (tasks.Count == tasks.Capacity)
                {
                    Log.Information("{P1} Contacts start processing", tasks.Count);
                    await Task.WhenAll(tasks);
                    Log.Information("{P1} Contacts finished processing", tasks.Count);
                    await Task.Delay(msLimit);
                    tasks.Clear();
                }
            }
            Log.Information("{P1} Contacts start processing", tasks.Count);
            await Task.WhenAll(tasks);
            Log.Information("{P1} Contacts finished processing", tasks.Count);
            tasks.Clear();
        }
    }
}