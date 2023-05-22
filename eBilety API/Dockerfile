#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 7180

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "eBilety API.csproj"
RUN dotnet build "eBilety API.csproj" -c Release -o /app/build

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS="http://+:8080;https://+:7180"

FROM build AS publish
RUN dotnet publish "eBilety API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eBilety API.dll"]