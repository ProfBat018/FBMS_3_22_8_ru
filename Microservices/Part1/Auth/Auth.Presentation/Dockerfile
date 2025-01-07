FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

RUN apt-get update && apt-get install -y protobuf-compiler

USER $APP_UID
WORKDIR /app
EXPOSE 5002


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Auth.Presentation/Auth.Presentation.csproj", "Auth.Presentation/"]
COPY ["Auth.Application/Auth.Application.csproj", "Auth.Application/"]
COPY ["Auth.Core/Auth.Core.csproj", "Auth.Core/"]
COPY ["Auth.Shared/Auth.Shared.csproj", "Auth.Shared/"]
COPY ["Auth.Infrastructure/Auth.Infrastructure.csproj", "Auth.Infrastructure/"]
RUN dotnet restore "Auth.Presentation/Auth.Presentation.csproj"
COPY . .
WORKDIR "/src/Auth.Presentation"
RUN dotnet build "Auth.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Auth.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth.Presentation.dll"]

