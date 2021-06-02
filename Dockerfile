
#FROM mcr.microfsoft.com/dotnet/core/sdk:3.0 AS build_env
#WORKDIR /app
#COPY .csproj ./
#RUN dotnet restore
#COPY . ./
#
#RUN dotnet publish -c Release -o out
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1
#
#WORKDIR /app
#EXPOSE 80
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "DockerAPI.dll"]
#

# 3
#FROM microsoft/aspnetcore
#FROM mcr.microsoft.com/dotnet/sdk:5.0
#WORKDIR /app
#COPY . .
#ENTRYPOINT ["dotnet", "dotnet-myapp.dll"]


# 2
#FROM mrc.microsoft.com/dotnet/core/sdk:3.1 as build-env
#WORKDIR /app
#
#COPY .csproj ./
#RUN dotnet restore
#
#COPY . ./
#RUN dotnet publish -c Release -o out
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster
#WORKDIR /app
#EXPOSE 80
#COPY --from=build-env /app/out .
##COPY --from=publish/app /app .
#ENTRYPOINT ["dotnet", "DockerAPI.dll"]


#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY hod-back.csproj hod-back/
RUN dotnet restore hod-back/hod-back.csproj
WORKDIR /src/hod-back
COPY . .
RUN dotnet build hod-back.csproj -c Release -o /app

#FROM build AS publish
#WORKDIR /src/hod-back
#RUN dotnet publish hod-back.csproj -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "hod-back.dll"]
