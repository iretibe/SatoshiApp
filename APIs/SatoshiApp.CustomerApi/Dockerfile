#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["APIs/SatoshiApp.CustomerApi/SatoshiApp.CustomerApi.csproj", "APIs/SatoshiApp.CustomerApi/"]
RUN dotnet restore "APIs/SatoshiApp.CustomerApi/SatoshiApp.CustomerApi.csproj"
COPY . .
WORKDIR "/src/APIs/SatoshiApp.CustomerApi"
RUN dotnet build "SatoshiApp.CustomerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SatoshiApp.CustomerApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SatoshiApp.CustomerApi.dll"]