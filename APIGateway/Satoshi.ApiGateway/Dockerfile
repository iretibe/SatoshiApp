#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["APIGateway/Satoshi.ApiGateway/Satoshi.ApiGateway.csproj", "APIGateway/Satoshi.ApiGateway/"]
RUN dotnet restore "APIGateway/Satoshi.ApiGateway/Satoshi.ApiGateway.csproj"
COPY . .
WORKDIR "/src/APIGateway/Satoshi.ApiGateway"
RUN dotnet build "Satoshi.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Satoshi.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Satoshi.ApiGateway.dll"]