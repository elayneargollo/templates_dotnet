#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT Staging
ENV CLIENT_SECRET=zRT8Q~b-AOYVChR7JHxqYwW6mpnVIzc1u7lGTbZ3
ENV TENANT_ID=c5dade78-23ca-4c48-86c5-ab8a9cdf6d79
ENV CLIENT_ID=75328048-5f1e-4c64-8aff-29a4354e8ef5
ENV KEY_VAULT_NAME=enmoraisvr

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["apidefault6.csproj", "."]
RUN dotnet restore "./././apidefault6.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./apidefault6.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./apidefault6.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "apidefault6.dll"]