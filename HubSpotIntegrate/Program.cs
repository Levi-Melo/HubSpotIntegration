using HubsportIntegrate.Extensions;
using HubSpotIntegrate.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.Inject();

using IHost host = builder.Build();
var facade = host.Services.GetRequiredService<IIntegrationFacade>();
var start = DateTime.Now;
await facade.MultiProcess();

Log.Information("Process started at {P1} and finished at {P2}", start, DateTime.Now);
