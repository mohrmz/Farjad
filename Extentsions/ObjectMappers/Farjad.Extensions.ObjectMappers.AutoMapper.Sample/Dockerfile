#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Farjad.Extensions.ObjectMappers.AutoMapper.Sample/Farjad.Extensions.ObjectMappers.AutoMapper.Sample.csproj", "Farjad.Extensions.ObjectMappers.AutoMapper.Sample/"]
RUN dotnet restore "Farjad.Extensions.ObjectMappers.AutoMapper.Sample/Farjad.Extensions.ObjectMappers.AutoMapper.Sample.csproj"
COPY . .
WORKDIR "/src/Farjad.Extensions.ObjectMappers.AutoMapper.Sample"
RUN dotnet build "Farjad.Extensions.ObjectMappers.AutoMapper.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Farjad.Extensions.ObjectMappers.AutoMapper.Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Farjad.Extensions.ObjectMappers.AutoMapper.Sample.dll"]