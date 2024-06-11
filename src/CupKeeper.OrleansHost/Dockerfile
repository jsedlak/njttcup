FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CupKeeper.OrleansHost/CupKeeper.OrleansHost.csproj", "src/CupKeeper.OrleansHost/"]
RUN dotnet restore "src/CupKeeper.OrleansHost/CupKeeper.OrleansHost.csproj"
COPY . .
WORKDIR "/src/src/CupKeeper.OrleansHost"
RUN dotnet build "CupKeeper.OrleansHost.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CupKeeper.OrleansHost.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CupKeeper.OrleansHost.dll"]
