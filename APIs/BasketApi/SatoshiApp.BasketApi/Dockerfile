#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["APIs/BasketApi/SatoshiApp.BasketApi/SatoshiApp.BasketApi.csproj", "APIs/BasketApi/SatoshiApp.BasketApi/"]
RUN dotnet restore "APIs/BasketApi/SatoshiApp.BasketApi/SatoshiApp.BasketApi.csproj"
COPY . .
WORKDIR "/src/APIs/BasketApi/SatoshiApp.BasketApi"
RUN dotnet build "SatoshiApp.BasketApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SatoshiApp.BasketApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SatoshiApp.BasketApi.dll"]