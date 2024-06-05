FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Hony.Web/Hony.Web.csproj", "src/Hony.Web/"]
RUN dotnet restore "src/Hony.Web/Hony.Web.csproj"
COPY . .
WORKDIR "/src/src/Hony.Web"
RUN dotnet build "Hony.Web.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Hony.Web.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hony.Web.dll"]
