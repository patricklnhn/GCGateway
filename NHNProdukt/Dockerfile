#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NHNProdukt/NHNProdukt.csproj", "NHNProdukt/"]
RUN dotnet restore "NHNProdukt/NHNProdukt.csproj"
COPY . .
WORKDIR "/src/NHNProdukt"
RUN dotnet build "NHNProdukt.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NHNProdukt.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NHNProdukt.dll"]