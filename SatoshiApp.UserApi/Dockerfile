#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SatoshiApp.UserApi/SatoshiApp.UserApi.csproj", "SatoshiApp.UserApi/"]
RUN dotnet restore "SatoshiApp.UserApi/SatoshiApp.UserApi.csproj"
COPY . .
WORKDIR "/src/SatoshiApp.UserApi"
RUN dotnet build "SatoshiApp.UserApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SatoshiApp.UserApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SatoshiApp.UserApi.dll"]