#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN cd .. 
WORKDIR /src
COPY . .
COPY ["MontyHall.API/MontyHall.API.csproj", "MontyHall.API/"]
RUN dotnet restore "MontyHall.API/MontyHall.API.csproj"
COPY . .
WORKDIR "/src/MontyHall.API"
RUN dotnet build "MontyHall.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MontyHall.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MontyHall.API.dll"]
