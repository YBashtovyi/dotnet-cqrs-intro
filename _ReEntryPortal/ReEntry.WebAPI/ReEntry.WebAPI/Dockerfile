#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReEntry.WebAPI/ReEntry.WebAPI.csproj", "ReEntry.WebAPI/"]
RUN dotnet restore "ReEntry.WebAPI/ReEntry.WebAPI.csproj"
COPY . .
WORKDIR "/src/ReEntry.WebAPI"
RUN dotnet build "ReEntry.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReEntry.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReEntry.WebAPI.dll"]