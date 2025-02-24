#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SwiftSuds.Order.Api/SwiftSuds.Order.Api.csproj", "src/SwiftSuds.Order.Api/"]
RUN dotnet restore "./src/SwiftSuds.Order.Api/SwiftSuds.Order.Api.csproj"
COPY . .
WORKDIR "/src/src/SwiftSuds.Order.Api"
RUN dotnet build "./SwiftSuds.Order.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS test
WORKDIR /src
COPY ["src/SwiftSuds.Application.Tests/SwiftSuds.Application.Tests.csproj", "src/SwiftSuds.Application.Tests/"]
COPY ["src/SwiftSuds.Order.Api.Tests/SwiftSuds.Order.Api.Tests.csproj", "src/SwiftSuds.Order.Api.Tests/"]
RUN dotnet restore "./src/SwiftSuds.Application.Tests/SwiftSuds.Application.Tests.csproj"
RUN dotnet restore "./src/SwiftSuds.Order.Api.Tests/SwiftSuds.Order.Api.Tests.csproj"
#RUN dotnet test -c Release --results-directory /testresults --logger "trx;LogFileName=application_test_results.trx" ./src/SwiftSuds.Application.Tests/SwiftSuds.Application.Tests.csproj
#RUN dotnet test -c Release --results-directory /testresults --logger "trx;LogFileName=api_test_results.trx" ./src/SwiftSuds.Order.Api.Tests/SwiftSuds.Order.Api.Tests.csproj


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SwiftSuds.Order.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SwiftSuds.Order.Api.dll"]