FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GCGateway/GCGateway.csproj", "GCGateway/"]
RUN dotnet restore "GCGateway/GCGateway.csproj"
COPY . .
WORKDIR "/src/GCGateway"
RUN dotnet build "GCGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GCGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GCGateway.dll"]
