#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Providor/Providor.csproj", "Providor/"]
COPY ["Providor.Business/Providor.Business.csproj", "Providor.Business/"]
COPY ["Providor.Data/Providor.Data.csproj", "Providor.Data/"]
RUN dotnet restore "Providor/Providor.csproj"
COPY . .
WORKDIR "/src/Providor"
RUN dotnet build "Providor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Providor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Providor.dll"]