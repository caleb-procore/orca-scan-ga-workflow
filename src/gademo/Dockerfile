FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/gademo  # Set the working directory for the build step

# Copy only the .csproj file to restore dependencies
COPY ["gademo.csproj", "./"]  # Adjust based on context if running from 'src/gademo'
RUN dotnet restore "gademo.csproj"

# Copy the rest of the project files
COPY . .

# Build the project
RUN dotnet build "gademo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "gademo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gademo.dll"]
