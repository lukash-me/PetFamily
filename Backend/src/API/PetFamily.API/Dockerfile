FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend/src/API/PetFamily.API/PetFamily.API.csproj", "Backend/src/API/PetFamily.API/"]
COPY ["Backend/src/Application/PetFamily.Application/PetFamily.Application.csproj", "Backend/src/Application/PetFamily.Application/"]
COPY ["Backend/src/Domain/PetFamily.Domain/PetFamily.Domain.csproj", "Backend/src/Domain/PetFamily.Domain/"]
COPY ["Backend/src/Infrastructure/PetFamily.Infrastructure/PetFamily.Infrastructure.csproj", "Backend/src/Infrastructure/PetFamily.Infrastructure/"]
RUN dotnet restore "Backend/src/API/PetFamily.API/PetFamily.API.csproj"
COPY . .
WORKDIR "/src/Backend/src/API/PetFamily.API"
RUN dotnet build "PetFamily.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PetFamily.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFamily.API.dll"]
