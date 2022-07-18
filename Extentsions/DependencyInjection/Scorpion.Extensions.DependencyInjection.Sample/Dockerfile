#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Scorpion.Extensions.DependencyInjection.Sample/Scorpion.Extensions.DependencyInjection.Sample.csproj", "Scorpion.Extensions.DependencyInjection.Sample/"]
RUN dotnet restore "Scorpion.Extensions.DependencyInjection.Sample/Scorpion.Extensions.DependencyInjection.Sample.csproj"
COPY . .
WORKDIR "/src/Scorpion.Extensions.DependencyInjection.Sample"
RUN dotnet build "Scorpion.Extensions.DependencyInjection.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scorpion.Extensions.DependencyInjection.Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scorpion.Extensions.DependencyInjection.Sample.dll"]