#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api_Gateway/Api_Gateway.csproj", "Api_Gateway/"]
RUN dotnet restore "Api_Gateway/Api_Gateway.csproj"
COPY . .
WORKDIR "/src/Api_Gateway"
RUN dotnet build "Api_Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api_Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api_Gateway.dll"]