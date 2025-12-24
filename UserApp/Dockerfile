FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app
RUN adduser --disabled-password --home /app --gecos '' appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["UserApp.csproj", "."]
RUN dotnet restore "UserApp.csproj"
COPY ["Program.cs", "."]
RUN dotnet build "UserApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER appuser
ENTRYPOINT ["dotnet", "UserApp.dll"]
