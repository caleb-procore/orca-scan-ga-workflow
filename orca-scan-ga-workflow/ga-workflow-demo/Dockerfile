FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ga-workflow-demo/ga-workflow-demo.csproj", "ga-workflow-demo/"]
RUN dotnet restore "ga-workflow-demo/ga-workflow-demo.csproj"
COPY . .
WORKDIR "/src/ga-workflow-demo"
RUN dotnet build "ga-workflow-demo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ga-workflow-demo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ga-workflow-demo.dll"]
