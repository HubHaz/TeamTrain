# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["TeamTrain.WebApi/TeamTrain.WebApi.csproj", "TeamTrain.WebApi/"]
RUN dotnet restore "TeamTrain.WebApi/TeamTrain.WebApi.csproj"
COPY . .
WORKDIR "/src/TeamTrain.WebApi"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamTrain.WebApi.dll"]
