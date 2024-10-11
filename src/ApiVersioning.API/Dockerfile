FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ApiVersioning.API/ApiVersioning.API.csproj", "src/ApiVersioning.API/"]
RUN dotnet restore "./src/ApiVersioning.API/ApiVersioning.API.csproj"
COPY . .
WORKDIR "/src/src/ApiVersioning.API"
RUN dotnet build "./ApiVersioning.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApiVersioning.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiVersioning.API.dll"]