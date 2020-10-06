#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Learning.Shop.API/Learning.Shop.API.csproj", "Learning.Shop.API/"]
RUN dotnet restore "Learning.Shop.API/Learning.Shop.API.csproj"
COPY . .
WORKDIR "/src/Learning.Shop.API"
RUN dotnet build "Learning.Shop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Learning.Shop.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Learning.Shop.API.dll"]