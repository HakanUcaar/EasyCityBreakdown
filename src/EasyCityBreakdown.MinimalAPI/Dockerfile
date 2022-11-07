#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./EasyCityBreakdown.MinimalAPI.csproj"
RUN dotnet build "./EasyCityBreakdown.MinimalAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyCityBreakdown.MinimalAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyCityBreakdown.MinimalAPI.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet EasyCityBreakdown.MinimalAPI.dll