# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./CoolRpg.csproj" --disable-parallel
RUN dotnet publish "./CoolRpg.csproj" -c release -o /app --no-restore

# Serve stage
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80

ENTRYPOINT ["dotnet", "CoolRpg.dll"]