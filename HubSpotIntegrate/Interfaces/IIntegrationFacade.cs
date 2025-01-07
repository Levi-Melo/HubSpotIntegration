namespace HubSpotIntegrate.Interfaces
{
    /// <summary>
    /// Defines the contract for integration services.
    /// </summary>
    public interface IIntegrationFacade
    {
        /// <summary>
        /// Processes the integration using multiple processes.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task MultiProcess();
    }
}