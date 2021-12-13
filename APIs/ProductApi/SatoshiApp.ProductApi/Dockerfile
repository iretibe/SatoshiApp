#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["APIs/ProductApi/SatoshiApp.ProductApi/SatoshiApp.ProductApi.csproj", "APIs/ProductApi/SatoshiApp.ProductApi/"]
RUN dotnet restore "APIs/ProductApi/SatoshiApp.ProductApi/SatoshiApp.ProductApi.csproj"
COPY . .
WORKDIR "/src/APIs/ProductApi/SatoshiApp.ProductApi"
RUN dotnet build "SatoshiApp.ProductApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SatoshiApp.ProductApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SatoshiApp.ProductApi.dll"]
