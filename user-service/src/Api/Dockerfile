# Stage 1: BUILD
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore src/Api/UserService.Api.csproj
RUN dotnet build src/Api/UserService.Api.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ARG ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_ENVIRONMENT=${ASPNETCORE_ENVIRONMENT}

EXPOSE 5000
ENTRYPOINT ["dotnet", "UserService.Api.dll"]