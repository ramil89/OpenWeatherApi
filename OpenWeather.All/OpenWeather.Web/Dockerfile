FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src

ENV NODE_VERSION 10.15.3 
ENV NODE_DOWNLOAD_URL https://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz 
ENV NODE_DOWNLOAD_SHA 6c35b85a7cd4188ab7578354277b2b2ca43eacc864a2a16b3669753ec2369d52 
  
RUN curl -SL "$NODE_DOWNLOAD_URL" --output nodejs.tar.gz \ 
     && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \ 
     && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \ 
     && rm nodejs.tar.gz \ 
     && ln -s /usr/local/bin/node /usr/local/bin/nodejs 

COPY ["OpenWeather.Web/OpenWeather.Web.csproj", "OpenWeather.Web/"]
RUN dotnet restore "OpenWeather.Web/OpenWeather.Web.csproj"
COPY . .
WORKDIR "/src/OpenWeather.Web"
RUN dotnet build "OpenWeather.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OpenWeather.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OpenWeather.Web.dll"]