#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY BlazorWeather.Api/BlazorWeather.Api.csproj BlazorWeather.Api/
COPY BlazorWeather.Api.Contracts/BlazorWeather.Api.Contracts.csproj BlazorWeather.Api.Contracts/
RUN dotnet restore BlazorWeather.Api/BlazorWeather.Api.csproj
COPY . .
WORKDIR /src/BlazorWeather.Api
RUN dotnet build BlazorWeather.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish BlazorWeather.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlazorWeather.Api.dll"]
