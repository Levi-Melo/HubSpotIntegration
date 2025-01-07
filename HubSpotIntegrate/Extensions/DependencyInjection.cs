using HubSpotIntegrate.Facades;
using HubSpotIntegrate.Gateways;
using HubSpotIntegrate.Interfaces;
using HubSpotIntegrate.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace HubsportIntegrate.Extensions
{
    /// <summary>
    /// Provides extension methods for dependency injection.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures and injects dependencies into the provided <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="serviceCollection">The service collection to add dependencies to.</param>
        public static void Inject(this IServiceCollection serviceCollection)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(configuration)
              .CreateLogger();

            Log.Information("Initializing dependencies");

            Log.Information("Configuration initialized");

            serviceCollection.AddTransient<IAwsGateway>(sp =>
                new AwsGateway(
                    configuration["Aws:Url"],
                    configuration["Aws:Token"]
                )
            );

            serviceCollection.AddTransient<IHubspotGateway>(sp =>
                new HubspotGateway(
                    configuration["Hubspot:Url"],
                    configuration["Hubspot:Token"]
                )
            );

            serviceCollection.AddTransient<ILegacyHubspotGateway>(sp =>
                new LegacyHubspotGateway(
                    configuration["LegacyHubspot:Url"],
                    configuration["LegacyHubspot:Token"]
                )
            );

            Log.Information("ContactService dependencies resolved");
            serviceCollection.AddScoped<IContactService, ContactService>();


            serviceCollection.AddScoped<IIntegrationFacade, IntegrationFacade>(sp =>
                new IntegrationFacade(
                    sp.GetRequiredService<IContactService>(),
                    Int32.Parse(configuration["RateLimit:capacity"]),
                    Int32.Parse(configuration["RateLimit:ms"])
                )
            );

            Log.Information("IntegrationService dependencies resolved");

            Log.Information("All dependencies resolved");
        }
    }
}
