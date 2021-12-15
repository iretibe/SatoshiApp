#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["APIs/DiscountApi/SatoshiApp.DiscountApi/SatoshiApp.DiscountApi.csproj", "APIs/DiscountApi/SatoshiApp.DiscountApi/"]
RUN dotnet restore "APIs/DiscountApi/SatoshiApp.DiscountApi/SatoshiApp.DiscountApi.csproj"
COPY . .
WORKDIR "/src/APIs/DiscountApi/SatoshiApp.DiscountApi"
RUN dotnet build "SatoshiApp.DiscountApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SatoshiApp.DiscountApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SatoshiApp.DiscountApi.dll"]