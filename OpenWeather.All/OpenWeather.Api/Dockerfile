FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["OpenWeather.Api/OpenWeather.Api.csproj", "OpenWeather.Api/"]
RUN dotnet restore "OpenWeather.Api/OpenWeather.Api.csproj"
COPY . .
WORKDIR "/src/OpenWeather.Api"
RUN dotnet build "OpenWeather.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OpenWeather.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OpenWeather.Api.dll"]