FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
EXPOSE 2135

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["filed.csproj", "./"]
RUN dotnet restore "filed.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "filed.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "filed.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "filed.dll"]
