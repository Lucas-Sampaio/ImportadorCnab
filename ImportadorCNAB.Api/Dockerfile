#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ImportadorCNAB.Api/ImportadorCNAB.Api.csproj", "ImportadorCNAB.Api/"]
COPY ["ImportadorCNAB.Infra/ImportadorCNAB.Infra.csproj", "ImportadorCNAB.Infra/"]
COPY ["ImportadorCNAB.Domain/ImportadorCNAB.Domain.csproj", "ImportadorCNAB.Domain/"]
COPY ["ImportadorCNAB.Shared/ImportadorCNAB.Shared.csproj", "ImportadorCNAB.Shared/"]
RUN dotnet restore "ImportadorCNAB.Api/ImportadorCNAB.Api.csproj"
COPY . .
WORKDIR "/src/ImportadorCNAB.Api"
RUN dotnet build "ImportadorCNAB.Api.csproj" -c Release -o /app/build

# Configurar o certificado de desenvolvedor HTTPS
#RUN dotnet dev-certs https --clean
#RUN dotnet dev-certs https --trust
#RUN dotnet dev-certs https --check --trust


FROM build AS publish
RUN dotnet publish "ImportadorCNAB.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ImportadorCNAB.Api.dll"]