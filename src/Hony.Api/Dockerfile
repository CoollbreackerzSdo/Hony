FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app
EXPOSE 8081
EXPOSE 8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Hony.Api/Hony.Api.csproj", "src/Hony.Api/"]
COPY ["src/Hony.Application/Hony.Application.csproj", "src/Hony.Application/"]
COPY ["src/Hony.Domain/Hony.Domain.csproj", "src/Hony.Domain/"]
COPY ["src/Hony.Infrastructure/Hony.Infrastructure.csproj", "src/Hony.Infrastructure/"]
RUN dotnet restore "src/Hony.Api/Hony.Api.csproj"
COPY . .
WORKDIR "/src/src/Hony.Api"
RUN dotnet build "Hony.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Hony.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hony.Api.dll"]
