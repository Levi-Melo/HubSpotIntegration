FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY ["HubSpotIntegrate/HubSpotIntegrate.csproj", "HubSpotIntegrate/"]

RUN dotnet restore "HubSpotIntegrate/HubSpotIntegrate.csproj"

COPY . .

WORKDIR "/src"
RUN dotnet build "HubSpotIntegrate/HubSpotIntegrate.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app


EXPOSE 80

COPY --from=build /app/build /app


ENTRYPOINT ["dotnet", "HubSpotIntegrate.dll"]