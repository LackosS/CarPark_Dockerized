#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarParkSystem.Tests/CarParkSystem.Tests.csproj", "CarParkSystem.Tests/"]
COPY ["CarParkSystem/CarParkSystem.csproj", "CarParkSystem/"]
COPY ["CarParkSystem.Persistence/CarParkSystem.Persistence.csproj", "CarParkSystem.Persistence/"]
RUN dotnet restore "CarParkSystem.Tests/CarParkSystem.Tests.csproj"
COPY . .
WORKDIR "/src/CarParkSystem.Tests"
RUN dotnet build "CarParkSystem.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarParkSystem.Tests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarParkSystem.Tests.dll"]