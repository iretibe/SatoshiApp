#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["APIGateway/SatoshiApp.Aggregator/SatoshiApp.Aggregator.csproj", "APIGateway/SatoshiApp.Aggregator/"]
RUN dotnet restore "APIGateway/SatoshiApp.Aggregator/SatoshiApp.Aggregator.csproj"
COPY . .
WORKDIR "/src/APIGateway/SatoshiApp.Aggregator"
RUN dotnet build "SatoshiApp.Aggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SatoshiApp.Aggregator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SatoshiApp.Aggregator.dll"]