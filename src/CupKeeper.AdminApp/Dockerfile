FROM nginx AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CupKeeper.AdminApp/CupKeeper.AdminApp.csproj", "src/CupKeeper.AdminApp/"]
COPY ["tazor/src/Tazor.Components/Tazor.Components.csproj", "tazor/src/Tazor.Components/"]
COPY ["tazor/src/Tazor.Core/Tazor.Core.csproj", "tazor/src/Tazor.Core/"]
COPY ["tazor/src/Tazor.Http/Tazor.Http.csproj", "tazor/src/Tazor.Http/"]
COPY ["tazor/src/Tazor.Wasm/Tazor.Wasm.csproj", "tazor/src/Tazor.Wasm/"]
RUN dotnet restore "src/CupKeeper.AdminApp/CupKeeper.AdminApp.csproj"
COPY . .
WORKDIR "/src/src/CupKeeper.AdminApp"
RUN dotnet build "CupKeeper.AdminApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CupKeeper.AdminApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY  "src/CupKeeper.AdminApp/nginx.conf" /etc/nginx/nginx.conf

