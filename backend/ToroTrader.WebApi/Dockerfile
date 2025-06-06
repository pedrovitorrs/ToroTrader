# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

# Adiciona o wait-for-it
ENV WAIT_VERSION 2.7.2
ADD https://github.com/ufoscout/docker-compose-wait/releases/download/${WAIT_VERSION}/wait /wait
RUN chmod +x /wait

USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ToroTrader.WebApi/ToroTrader.WebApi.csproj", "ToroTrader.WebApi/"]
COPY ["ToroTrader.Infra/ToroTrader.Infra.IoC/ToroTrader.Infra.IoC.csproj", "ToroTrader.Infra/ToroTrader.Infra.IoC/"]
COPY ["ToroTrader.Application/ToroTrader.Application.Domain/ToroTrader.Application.Domain.csproj", "ToroTrader.Application/ToroTrader.Application.Domain/"]
COPY ["ToroTrader.Application/ToroTrader.Application/ToroTrader.Application.csproj", "ToroTrader.Application/ToroTrader.Application/"]
COPY ["ToroTrader.Infra/ToroTrader.Infra.Data/ToroTrader.Infra.Data.csproj", "ToroTrader.Infra/ToroTrader.Infra.Data/"]
COPY ["ToroTrader.Infra/ToroTrader.Infra.Messaging/ToroTrader.Infra.Messaging/ToroTrader.Infra.Messaging.csproj", "ToroTrader.Infra/ToroTrader.Infra.Messaging/ToroTrader.Infra.Messaging/"]
RUN dotnet restore "./ToroTrader.WebApi/ToroTrader.WebApi.csproj"
COPY . .
WORKDIR "/src/ToroTrader.WebApi"
RUN dotnet build "./ToroTrader.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ToroTrader.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ToroTrader.WebApi.dll"]