#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["APIs/OrderApi/SatoshiApp.OrderApi/SatoshiApp.OrderApi.csproj", "APIs/OrderApi/SatoshiApp.OrderApi/"]
COPY ["APIs/OrderApi/SatoshiApp.OrderApi.Domain/SatoshiApp.OrderApi.Domain.csproj", "APIs/OrderApi/SatoshiApp.OrderApi.Domain/"]
COPY ["APIs/OrderApi/SatoshiApp.OrderApi.Infrastructure/SatoshiApp.OrderApi.Infrastructure.csproj", "APIs/OrderApi/SatoshiApp.OrderApi.Infrastructure/"]
COPY ["APIs/OrderApi/SatoshiApp.OrderApi.Application/SatoshiApp.OrderApi.Application.csproj", "APIs/OrderApi/SatoshiApp.OrderApi.Application/"]
COPY ["BuildingBlocks/SatoshiApp.EventBus.Messages/SatoshiApp.EventBus.Messages.csproj", "BuildingBlocks/SatoshiApp.EventBus.Messages/"]
RUN dotnet restore "APIs/OrderApi/SatoshiApp.OrderApi/SatoshiApp.OrderApi.csproj"
COPY . .
WORKDIR "/src/APIs/OrderApi/SatoshiApp.OrderApi"
RUN dotnet build "SatoshiApp.OrderApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SatoshiApp.OrderApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SatoshiApp.OrderApi.dll"]