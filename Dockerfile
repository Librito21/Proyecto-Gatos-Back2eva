FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["adoptaragon.csproj", "."]
RUN dotnet restore "./adoptaragon.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "adoptaragon.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "adoptaragon.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "adoptaragon.dll"]
