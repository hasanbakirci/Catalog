FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["catalog.csproj", "./"]
RUN dotnet restore "catalog.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "catalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "catalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "catalog.dll"]
