﻿FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["POEPart2.csproj", "./"]
RUN dotnet restore "POEPart2.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "POEPart2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POEPart2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POEPart2.dll"]
