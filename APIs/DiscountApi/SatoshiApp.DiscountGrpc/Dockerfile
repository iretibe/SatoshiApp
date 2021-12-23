#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["APIs/DiscountApi/SatoshiApp.DiscountGrpc/SatoshiApp.DiscountGrpc.csproj", "APIs/DiscountApi/SatoshiApp.DiscountGrpc/"]
RUN dotnet restore "APIs/DiscountApi/SatoshiApp.DiscountGrpc/SatoshiApp.DiscountGrpc.csproj"
COPY . .
WORKDIR "/src/APIs/DiscountApi/SatoshiApp.DiscountGrpc"
RUN dotnet build "SatoshiApp.DiscountGrpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SatoshiApp.DiscountGrpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SatoshiApp.DiscountGrpc.dll"]