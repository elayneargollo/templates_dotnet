FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["arquivoApi.csproj", "./"]
RUN dotnet restore "arquivoApi.csproj"

COPY . .
WORKDIR "/src/."
RUN dotnet build "arquivoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "arquivoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "arquivoApi.dll"]