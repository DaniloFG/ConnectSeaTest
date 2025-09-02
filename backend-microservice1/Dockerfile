FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ConnectSeaMs1Api/ConnectSeaMs1Api.csproj", "ConnectSeaMs1Api/"]
RUN dotnet restore "./ConnectSeaMs1Api/ConnectSeaMs1Api.csproj"
COPY . .
RUN dotnet build "./ConnectSeaMs1Api/ConnectSeaMs1Api.csproj" -o /src/build

FROM build AS publish
RUN dotnet publish "./ConnectSeaMs1Api/ConnectSeaMs1Api.csproj" -o /src/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /src
COPY --from=publish /src/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "ConnectSeaMs1Api.dll"]

