<div align="center">

[![Create Go App][repo_logo_img]][repo_url]

# Integrate on HubSpot api

Integrate all contacts from **AWS** (private data) to hubSpot contacts crm.

</div>

## ⚡️ Quick start

First, [download][.net_download_url] and install **.NET**. Version `8.0`.

> 👆 You can also use **Docker** instead of installing .net

Let's clone a our project via **GIT** :

```bash
git clone https://github.com/Levi-Melo/HubSpotIntegration.git
```
Or using SSH:

```bash
git clone git@github.com:Levi-Melo/HubSpotIntegration.git
```

Then, we restore our dependencies and build
```bash
dotnet restore
dotnet build
```

Next, we need to add our environment variables create a **appsettings.json** file on root of project using this template:

```json
{
  "Aws": {
    "Url": "",
    "Token": ""
  },
  "Hubspot": {
    "Url": "",
    "Token": ""
  },
  "LegacyHubspot": {
    "Url": "",
    "Token": ""
  },
  // Rate limit config to don't brake the HubSpot apis.
  // Default is 10 requisitions per second.
  "RateLimit": {
    "ms": 1000, 
    "capacity": 10
  },
  // Log dependency configuration.
  // Default level is Information but there is some debug in project too.
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information"
    },
    "WriteTo": [
      {
        "Name": "Console",
        "Args": { "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}" }
      }
    ]
  }
}
```

Now it's just run

```bash
dotnet run --project HubSpotIntegrate/HubSpotIntegrate.csproj
```
That's all you need to know to start! 🎉

### 🐳 Docker-way to quick start

If you don't want to install .NET to your system, build the image and run:

```bash
docker build -t {image_name} .
```

Then 

```bash
docker run {image_name}
```

> 🔔 Please note: on the `{image_name}` overwrite with the name of image you want.

## ⚙️ The application

### Process
This is a simple application to fetch contacts from a specific endpoint and convert to the right payload of HubSpot contact create and upsert apis.
This run a script where we divided the contacts in 2 with email and without email, the HubSpot contact api use contact as a index of their data, so instead of try create and if there is a conflict I divided and work simultaneous each one, I notice that the script was kinda low and start working with more threads on requests, but still need to throttle to not break the ratelimit of apis
   
![alt text][diagram_url]

### Layers
While we try to keep the app simple we still have need for some layers and divided contexts, so in this app we ha 3 main layers. 
 - **Facade** to create a abstraction to use everything without worry about rules and don't make our services dirt.
 - **Services** to deal with our contact model and consume all gateways.
 - **Gateways** to deal with all HTTPS request without it coming out to service.

### Tools

| Name                                                                       | Description                                                             |
| -------------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| [Microsoft.Extensions.Configuration.Abstraction][configuration_abstraction]| Provides abstractions of key-value pair based configuration             |
| [Microsoft.Extensions.Configuration.Json][configuration_json]              | Enables you to read your application's settings from a JSON file        |
| [Microsoft.Extensions.DependencyInjection][dependency_injection]           | Abstraction for dependency injection                                    |
| [Microsoft.Extensions.Hosting][hosting]                                    | Startup infrastructure                                                  |
| [Serilog.Settings.Configuration][serilog_configuration]                    | Allow us to our configuration to setup the logger                       |
| [Serilog.Sinks.Console][serilog_console]                                   | Provides a global logger to write in console                            |

<!-- .NET -->

[.net_download_url]: https://learn.microsoft.com/en-us/dotnet/core/install/windows#net-installer


<!-- Repository -->

[repo_url]: https://github.com/Levi-Melo/HubSpotIntegration
[repo_logo_url]: https://avatars.githubusercontent.com/u/326419?s=200&v=4
[repo_logo_img]: https://avatars.githubusercontent.com/u/326419?s=200&v=4
[diagram_url]: https://i.imgur.com/bf0DOob.png

<!-- Libraries -->
[configuration_abstraction]: https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Abstractions
[configuration_json]: https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json
[dependency_injection]: https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection
[hosting]: https://www.nuget.org/packages/Microsoft.Extensions.Hosting
[serilog_configuration]: https://www.nuget.org/packages/Serilog.Settings.Configuration
[serilog_console]: https://www.nuget.org/packages/Serilog.Sinks.Console

