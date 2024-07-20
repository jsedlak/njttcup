FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CupKeeper.AdminApi/CupKeeper.AdminApi.csproj", "src/CupKeeper.AdminApi/"]
RUN dotnet restore "src/CupKeeper.AdminApi/CupKeeper.AdminApi.csproj"
COPY . .
WORKDIR "/src/src/CupKeeper.AdminApi"
RUN dotnet build "CupKeeper.AdminApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CupKeeper.AdminApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CupKeeper.AdminApi.dll"]
