FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MoonlightNode/MoonlightNode.csproj", "MoonlightNode/"]
RUN dotnet restore "MoonlightNode/MoonlightNode.csproj"
COPY . .
WORKDIR "/src/MoonlightNode"
RUN dotnet build "MoonlightNode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MoonlightNode.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoonlightNode.dll"]
