# =========================
# Stage 1: Build
# =========================
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["web.csproj", "./"]
RUN dotnet restore "./web.csproj"

# Copy all project files
COPY . .
# Publish the project to /app/publish
RUN dotnet publish "./web.csproj" -c Release -o /app/publish

# =========================
# Stage 2: Runtime
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
# Expose port 80
EXPOSE 80

# Copy the published files from build stage
COPY --from=build /app/publish .

# Set entrypoint
ENTRYPOINT ["dotnet", "web.dll"]
