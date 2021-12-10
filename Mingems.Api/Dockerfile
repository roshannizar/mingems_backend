FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./Mingems.Api.csproj", "src/"]
RUN dotnet restore "src/Mingems.Api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Mingems.Api.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Mingems.Api.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "Mingems.Api.dll"]